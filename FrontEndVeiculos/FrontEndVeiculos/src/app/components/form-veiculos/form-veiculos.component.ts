import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Veiculo } from '../../models/veiculos';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { Router } from '@angular/router'; // Importação do Router
import { VeiculoService } from '../../services/veiculo.service';

// Angular Material
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@Component({
  selector: 'app-form-veiculos',
  standalone: true,
  templateUrl: './form-veiculos.component.html',
  styleUrls: ['./form-veiculos.component.css'],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    BrowserAnimationsModule
  ]
})
export class FormVeiculosComponent implements OnInit {

  @Output() onSubmit = new EventEmitter<Veiculo>();
  @Input() btnAcao!: string;
  @Input() btnTitulo!: string;
  @Input() dadosVeiculo: Veiculo | null = null;

  formularioVeiculo!: FormGroup;

  constructor(
    private veiculoService: VeiculoService,
    private router: Router // Injeção do Router
  ) {}

  ngOnInit(): void {
    this.formularioVeiculo = new FormGroup({
      id: new FormControl(this.dadosVeiculo?.id ?? 0),
      placa: new FormControl(this.dadosVeiculo?.placa ?? '', Validators.required),
      modelo: new FormControl(this.dadosVeiculo?.modelo ?? '', Validators.required),
      grupoId: new FormControl(this.dadosVeiculo?.grupoId ?? '', Validators.required),
    });
  }

  submit(): void {
    if (this.formularioVeiculo.valid) {
      const veiculoFormValue = this.formularioVeiculo.value;

      const veiculo: Veiculo = {
        ...veiculoFormValue,
        grupoId: Number(veiculoFormValue.grupoId) // conversão para número
      };

      // Emite o evento para o componente pai (se necessário)
      this.onSubmit.emit(veiculo);

    } else {
      this.formularioVeiculo.markAllAsTouched();
    }
  }
}
