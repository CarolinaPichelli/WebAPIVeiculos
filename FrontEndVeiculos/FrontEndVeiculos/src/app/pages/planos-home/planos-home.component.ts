import { Component, OnInit } from '@angular/core';
import { PlanoService } from '../../services/plano.service';
import { Plano } from '../../models/planos';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-planos-home',
  standalone: false,
  templateUrl: './planos-home.component.html',
  styleUrl: './planos-home.component.css'
})
export class PlanosHomeComponent implements OnInit{

  planos: Plano[] = []; 
  planosGeral: Plano[] = []; 
  planoId!: number;

  constructor(private planoService: PlanoService, public dialog: MatDialog) { }
  ngOnInit(): void {
    
    this.planoService.GetPlanos().subscribe(data => {
      this.planos = data;
      this.planosGeral = data;

  });
}

  // Método chamado quando a exclusão for confirmada
  onConfirmDelete(planoId: number): void {
    this.planoService.DeletePlano(planoId).subscribe({
      next: () => {
        console.log('Plano excluído com sucesso!');
        // Remover o plano da lista ou redirecionar, conforme necessário
        this.planos = this.planos.filter(plano => plano.id !== planoId);
      },
      error: (err) => console.error('Erro ao excluir plano:', err)
    });
  }

  // Abre o modal de exclusão
  openDeleteModal(planoId: number): void {
    this.planoId = planoId;
  }
}
