import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Veiculo } from '../../models/veiculos';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { Router } from '@angular/router'; // Importação do Router

// Angular Material
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { Empresa } from '../../models/empresas';
import { EmpresaService } from '../../services/empresa.service';

@Component({
  selector: 'app-form-empresas',
  standalone: true,
  templateUrl: './form-empresas.component.html',
  styleUrl: './form-empresas.component.css',
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    BrowserAnimationsModule
  ]
})
export class FormEmpresasComponent implements OnInit{
  @Output() onSubmit = new EventEmitter<Empresa>();
  @Input() btnAcao!: string;
  @Input() btnTitulo!: string;
  @Input() dadosEmpresa: Empresa | null = null;

  formularioEmpresa!: FormGroup;

  constructor(
    private empresaService: EmpresaService,
    private router: Router // Injeção do Router
  ) {}

  ngOnInit(): void {
    this.formularioEmpresa = new FormGroup({
      id: new FormControl(this.dadosEmpresa?.id ?? 0),
      nome: new FormControl(this.dadosEmpresa?.nome ?? '', Validators.required),
      endereco: new FormControl(this.dadosEmpresa?.endereco ?? '', Validators.required),
    });
  }

  
  submit(): void {
    if (this.formularioEmpresa.valid) {
      const grupoFormValue = this.formularioEmpresa.value;
      // Emite o evento para o componente pai (se necessário)
      this.onSubmit.emit(grupoFormValue);

    } else {
      this.formularioEmpresa.markAllAsTouched();
    }
  }

}

