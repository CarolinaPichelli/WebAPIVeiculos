import { Component } from '@angular/core';
import { Grupo } from '../../models/grupos';
import { GrupoService } from '../../services/grupo.service';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-grupos-home',
  standalone: false,
  templateUrl: './grupos-home.component.html',
  styleUrl: './grupos-home.component.css'
})
export class GruposHomeComponent {
  grupos: Grupo[] = []; 
  gruposGeral: Grupo[] = []; 
  grupoId!: number;

  constructor(private grupoService: GrupoService, public dialog: MatDialog) { }
  ngOnInit(): void {
    
    this.grupoService.GetGrupos().subscribe(data => {
      this.grupos = data;
      this.gruposGeral = data;

  });
}

  // Método chamado quando a exclusão for confirmada
  onConfirmDelete(gruposId: number): void {
    this.grupoService.DeleteGrupo(this.grupoId).subscribe({
      next: () => {
        console.log('Grupo excluído com sucesso!');
        // Remover o veículo da lista ou redirecionar, conforme necessário
        this.grupos = this.grupos.filter(grupo => grupo.id !== this.grupoId);
      },
      error: (err) => console.error('Erro ao excluir veículo:', err)
    });
  }

  // Abre o modal de exclusão
  openDeleteModal(grupoId: number): void {
    this.grupoId = grupoId;
  }
}
