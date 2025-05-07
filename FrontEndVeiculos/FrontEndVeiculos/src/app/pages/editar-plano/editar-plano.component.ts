import { Component } from '@angular/core';
import { PlanoService } from '../../services/plano.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Plano } from '../../models/planos';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-editar-plano',
  standalone: false,
  templateUrl: './editar-plano.component.html',
  styleUrl: './editar-plano.component.css'
})
export class EditarPlanoComponent {

  btnAcao = "Editar";
  btnTitulo = "Editar Plano";
  plano!: Plano;  // Variável que será preenchida após a resposta da API
  formularioPlano!: FormGroup;  // Declarando o formulário

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private fb: FormBuilder,
    private planoService: PlanoService
  ) {}

  ngOnInit(): void {
    // Recuperando o id da rota para buscar o plano
    const planoId = Number(this.route.snapshot.paramMap.get('id'));
    this.inicializarFormulario();

    // Buscando o veículo pelo id
    this.planoService.GetPlanoById(planoId).subscribe({
      next: (dados) => {
        this.plano = dados;  // Atribuindo os dados do veículo
        this.formularioPlano.patchValue(dados);  // Preenchendo o formulário com os dados
      },
      error: (err) => console.error('Erro ao buscar plano:', err)
    });
  }

  inicializarFormulario(): void {
    this.formularioPlano = this.fb.group({
      id: [0],
      descricao: ['', Validators.required],
      cobertura: ['', Validators.required],
      empresaId: [0, Validators.required]
    });
  }

  submit(): void {
    if (this.formularioPlano.valid) {
      if (!this.plano) {
        console.error("Plano não carregado.");
        return;  
      }
      
      // Usando o id do plano corretamente
      this.planoService.UpdatePlano(this.plano.id!, this.formularioPlano.value).subscribe({
        next: () => this.router.navigate(['/planos-home']),
        error: (err) => console.error('Erro ao atualizar plano:', err)
      });
    }
  }
}

//=====



 

