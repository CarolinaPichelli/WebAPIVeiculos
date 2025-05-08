import { Component } from '@angular/core';
import { VeiculoService } from '../../services/veiculo.service'; 
import { Veiculo } from '../../models/veiculos';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-veiculos-home',
  standalone: false,
  templateUrl: './veiculos-home.component.html',
  styleUrl: './veiculos-home.component.css'
})
export class VeiculosHomeComponent {
  veiculos: Veiculo[] = []; 
  veiculosGeral: Veiculo[] = []; 
  veiculoId!: number;

  constructor(private veiculoService: VeiculoService, public dialog: MatDialog) { }
  ngOnInit(): void {
    
    this.veiculoService.GetVeiculos().subscribe(data => {
      this.veiculos = data;
      this.veiculosGeral = data;

  });
}

  // Método chamado quando a exclusão for confirmada
  onConfirmDelete(veiculoId: number): void {
    this.veiculoService.DeleteVeiculo(veiculoId).subscribe({
      next: () => {
        console.log('Veículo excluído com sucesso!');
        // Remover o veículo da lista ou redirecionar, conforme necessário
        this.veiculos = this.veiculos.filter(veiculo => veiculo.id !== veiculoId);
      },
      error: (err) => console.error('Erro ao excluir veículo:', err)
    });
  }

  // Abre o modal de exclusão
  openDeleteModal(veiculoId: number): void {
    this.veiculoId = veiculoId;
  }
}







