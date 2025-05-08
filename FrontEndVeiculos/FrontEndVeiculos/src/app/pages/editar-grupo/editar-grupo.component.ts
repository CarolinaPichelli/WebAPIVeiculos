import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Grupo } from '../../models/grupos';
import { GrupoService } from '../../services/grupo.service';

@Component({
  selector: 'app-editar-grupo',
  standalone: false,
  templateUrl: './editar-grupo.component.html',
  styleUrl: './editar-grupo.component.css'
})
export class EditarGrupoComponent {
  btnAcao = "Editar";
  btnTitulo = "Editar Grupo";
  grupo!: Grupo;  // Variável que será preenchida após a resposta da API
  formularioGrupo!: FormGroup;  // Declarando o formulário

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private fb: FormBuilder,
    private grupoService: GrupoService
  ) {}

   
  ngOnInit(): void {
    // Recuperando o id da rota para buscar o grupo
    const grupoId = Number(this.route.snapshot.paramMap.get('id'));
    this.inicializarFormulario();
    this.grupoService.GetGrupoById(grupoId).subscribe({
      next: (dados) => {
        this.grupo = dados;  
        this.formularioGrupo.patchValue(dados);  // Preenchendo o formulário com os dados
      },
      error: (err) => console.error('Erro ao buscar o grupo:', err)
    });
  }

  inicializarFormulario(): void {
    this.formularioGrupo = this.fb.group({
      id: [0],
      nome: ['', Validators.required],
      descricao: ['', Validators.required],
    });
  }

  submit(): void {
    if (this.formularioGrupo.valid) {
      if (!this.grupo) {
        console.error("Grupo não carregado.");
        return;  
      }
      this.grupoService.UpdateGrupo(this.grupo.id!, this.formularioGrupo.value).subscribe({
        next: () => this.router.navigate(['/grupos-home']),
        error: (err) => console.error('Erro ao atualizar grupo:', err)
      });
    }
  }

}

