import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Assistencia } from '../../models/assistencias';
import { AssistenciaService } from '../../services/assistencia.service';

@Component({
  selector: 'app-editar-assistencia',
  standalone: false,
  templateUrl: './editar-assistencia.component.html',
  styleUrl: './editar-assistencia.component.css'
})
export class EditarAssistenciaComponent {
  btnAcao = "Editar";
  btnTitulo = "Editar Assistência de veículo";
  assistencia!: Assistencia; 
  formularioAssistencia!: FormGroup; 

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private fb: FormBuilder,
    private assistenciaService: AssistenciaService
  ) {}

  ngOnInit(): void {
    const assistenciaId = Number(this.route.snapshot.paramMap.get('id'));
    this.inicializarFormulario();

    this.assistenciaService.GetAssistenciaById(assistenciaId).subscribe({
      next: (dados) => {
        this.assistencia = dados;  
        this.formularioAssistencia.patchValue(dados);  // Preenchendo o formulário com os dados
      },
      error: (err) => console.error('Erro ao buscar assistência de veículo:', err)
    });
  }

  inicializarFormulario(): void {
    this.formularioAssistencia = this.fb.group({
      id: [0],      
      veiculoId: [0, Validators.required],
      planoId: [0, Validators.required],
    });
  }

  submit(): void {
    if (this.formularioAssistencia.valid) {
      if (!this.formularioAssistencia) {
        console.error("Assistência de veículo não carregado.");
        return;  
      }
      
      this.assistenciaService.UpdateAssistencia(this.assistencia.id!, this.formularioAssistencia.value).subscribe({
        next: () => this.router.navigate(['/assistencias-home']),
        error: (err) => console.error('Erro ao atualizar assistência de veículo:', err)
      });
    }
  }
}
