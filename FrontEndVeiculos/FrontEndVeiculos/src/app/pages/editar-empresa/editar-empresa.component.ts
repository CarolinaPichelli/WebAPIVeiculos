import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Empresa } from '../../models/empresas';
import { EmpresaService } from '../../services/empresa.service';

@Component({
  selector: 'app-editar-empresa',
  standalone: false,
  templateUrl: './editar-empresa.component.html',
  styleUrl: './editar-empresa.component.css'
})
export class EditarEmpresaComponent {

  btnAcao = "Editar";
  btnTitulo = "Editar Empresa";
  empresa!: Empresa;  // Variável que será preenchida após a resposta da API
  formularioEmpresa!: FormGroup;  // Declarando o formulário

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private fb: FormBuilder,
    private empresaService: EmpresaService
  ) {}

  ngOnInit(): void {
    // Recuperando o id da rota para buscar o grupo
    const empresaId = Number(this.route.snapshot.paramMap.get('id'));
    this.inicializarFormulario();

    // Buscando o veículo pelo id
    this.empresaService.GetEmpresaById(empresaId).subscribe({
      next: (dados) => {
        this.empresa = dados;  // Atribuindo os dados do veículo
        this.formularioEmpresa.patchValue(dados);  // Preenchendo o formulário com os dados
      },
      error: (err) => console.error('Erro ao buscar a empresa:', err)
    });
  }

  inicializarFormulario(): void {
    this.formularioEmpresa = this.fb.group({
      id: [0],
      nome: ['', Validators.required],
      endereco: ['', Validators.required],
    });
  }

  submit(): void {
    if (this.formularioEmpresa.valid) {
      if (!this.empresaService) {
        console.error("Empresa não carregada.");
        return;  
      }

      this.empresaService.UpdateEmpresa(this.empresa.id!, this.formularioEmpresa.value).subscribe({
        next: () => this.router.navigate(['/empresas-home']),
        error: (err) => console.error('Erro ao atualizar empresa:', err)
      });
    }
  }


}