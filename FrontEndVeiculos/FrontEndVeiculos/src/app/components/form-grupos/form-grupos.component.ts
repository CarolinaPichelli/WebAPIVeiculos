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
import { Grupo } from '../../models/grupos';
import { GrupoService } from '../../services/grupo.service';

@Component({
  selector: 'app-form-grupos',
  standalone: true,
  templateUrl: './form-grupos.component.html',
  styleUrl: './form-grupos.component.css',
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    BrowserAnimationsModule
  ]
})
export class FormGruposComponent implements OnInit{
  @Output() onSubmit = new EventEmitter<Grupo>();
  @Input() btnAcao!: string;
  @Input() btnTitulo!: string;
  @Input() dadosGrupo: Grupo | null = null;

  formularioGrupo!: FormGroup;

  constructor(
    private grupoService: GrupoService,
    private router: Router // Injeção do Router
  ) {}

  ngOnInit(): void {
    this.formularioGrupo = new FormGroup({
      id: new FormControl(this.dadosGrupo?.id ?? 0),
      nome: new FormControl(this.dadosGrupo?.nome ?? '', Validators.required),
      descricao: new FormControl(this.dadosGrupo?.descricao ?? '', Validators.required),
    });
  }

  submit(): void {
    if (this.formularioGrupo.valid) {
      const grupoFormValue = this.formularioGrupo.value;


      // Emite o evento para o componente pai (se necessário)
      this.onSubmit.emit(grupoFormValue);

    } else {
      this.formularioGrupo.markAllAsTouched();
    }
  }
}

