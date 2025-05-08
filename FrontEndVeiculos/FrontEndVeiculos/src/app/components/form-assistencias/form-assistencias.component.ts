import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Assistencia } from '../../models/assistencias';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { Router } from '@angular/router'; // Importação do Router
import { AssistenciaService } from '../../services/assistencia.service';

// Angular Material
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@Component({
  selector: 'app-form-assistencias',
  standalone: true,
  templateUrl: './form-assistencias.component.html',
  styleUrl: './form-assistencias.component.css',
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    BrowserAnimationsModule
  ]
})
export class FormAssistenciasComponent implements OnInit{

  @Output() onSubmit = new EventEmitter<Assistencia>();
  @Input() btnAcao!: string;
  @Input() btnTitulo!: string;
  @Input() dadosAssistencia: Assistencia | null = null;

  formularioAssistencia!: FormGroup;

  constructor(
    private assistenciaService: AssistenciaService,
    private router: Router 
  ) {}

  ngOnInit(): void {
    this.formularioAssistencia = new FormGroup({
      id: new FormControl(this.dadosAssistencia?.id ?? 0),
      veiculoId: new FormControl(this.dadosAssistencia?.veiculoId ?? '', Validators.required),
      planoId: new FormControl(this.dadosAssistencia?.planoId ?? '', Validators.required),
    });
  }

  submit(): void {
    if (this.formularioAssistencia.valid) {
      const assistenciaFormValue = this.formularioAssistencia.value;

      const assistencia: Assistencia = {
        ...assistenciaFormValue,
        veiculoId: Number(assistenciaFormValue.veiculoId), 
        planoId: Number(assistenciaFormValue.planoId) 
      };

      this.onSubmit.emit(assistencia);

    } else {
      this.formularioAssistencia.markAllAsTouched();
    }
  }

}
