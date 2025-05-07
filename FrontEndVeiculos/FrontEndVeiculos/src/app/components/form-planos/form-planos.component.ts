import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Plano } from '../../models/planos';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { Router } from '@angular/router'; // Importação do Router
import { PlanoService } from '../../services/plano.service';

// Angular Material
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'

@Component({
  selector: 'app-form-planos',
  standalone: true,
  templateUrl: './form-planos.component.html',
  styleUrl: './form-planos.component.css',
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    BrowserAnimationsModule
  ]
})
export class FormPlanosComponent implements OnInit{

  @Output() onSubmit = new EventEmitter<Plano>();
  @Input() btnAcao!: string;
  @Input() btnTitulo!: string;
  @Input() dadosPlano: Plano | null = null;

  formularioPlano!: FormGroup;

  constructor(
    private planoService: PlanoService,
    private router: Router // Injeção do Router
  ) {}

  ngOnInit(): void {
    this.formularioPlano = new FormGroup({
      id: new FormControl(this.dadosPlano?.id ?? 0),
      descricao: new FormControl(this.dadosPlano?.descricao ?? '', Validators.required),
      cobertura: new FormControl(this.dadosPlano?.cobertura ?? '', Validators.required),
      empresaId: new FormControl(this.dadosPlano?.empresaId ?? '', Validators.required),
    });
  }

  submit(): void {
    if (this.formularioPlano.valid) {
      const planoFormValue = this.formularioPlano.value;

      const plano: Plano = {
        ...planoFormValue,
        empresaId: Number(planoFormValue.empresaId) // conversão para número
      };

      // Emite o evento para o componente pai (se necessário)
      this.onSubmit.emit(plano);

    } else {
      this.formularioPlano.markAllAsTouched();
    }
  }

}

