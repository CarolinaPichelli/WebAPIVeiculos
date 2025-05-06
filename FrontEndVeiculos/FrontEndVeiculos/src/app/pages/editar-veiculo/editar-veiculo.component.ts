import { Component } from '@angular/core';
import { VeiculoService } from '../../services/veiculo.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Veiculo } from '../../models/veiculos';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { FormVeiculosComponent } from '../../components/form-veiculos/form-veiculos.component';

@Component({
  selector: 'app-editar-veiculo',
  standalone: false,
  templateUrl: './editar-veiculo.component.html',
  styleUrls: ['./editar-veiculo.component.css'],
})
export class EditarVeiculoComponent {
  btnAcao = "Editar";
  btnTitulo = "Editar Veículo";
  veiculo!: Veiculo;  // Variável que será preenchida após a resposta da API
  formularioVeiculo!: FormGroup;  // Declarando o formulário

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private fb: FormBuilder,
    private veiculoService: VeiculoService
  ) {}

  ngOnInit(): void {
    // Recuperando o id da rota para buscar o veículo
    const veiculoId = Number(this.route.snapshot.paramMap.get('id'));
    this.inicializarFormulario();

    // Buscando o veículo pelo id
    this.veiculoService.GetVeiculoById(veiculoId).subscribe({
      next: (dados) => {
        this.veiculo = dados;  // Atribuindo os dados do veículo
        this.formularioVeiculo.patchValue(dados);  // Preenchendo o formulário com os dados
      },
      error: (err) => console.error('Erro ao buscar veículo:', err)
    });
  }

  inicializarFormulario(): void {
    this.formularioVeiculo = this.fb.group({
      id: [0],
      placa: ['', Validators.required],
      modelo: ['', Validators.required],
      grupoId: [0, Validators.required]
    });
  }

  submit(): void {
    if (this.formularioVeiculo.valid) {
      if (!this.veiculo) {
        console.error("Veículo não carregado.");
        return;  // Evita enviar o formulário antes de carregar os dados do veículo
      }
      
      // Usando o id do veículo corretamente
      this.veiculoService.UpdateVeiculo(this.veiculo.id, this.formularioVeiculo.value).subscribe({
        next: () => this.router.navigate(['/veiculo-home']),
        error: (err) => console.error('Erro ao atualizar veículo:', err)
      });
    }
  }
}
