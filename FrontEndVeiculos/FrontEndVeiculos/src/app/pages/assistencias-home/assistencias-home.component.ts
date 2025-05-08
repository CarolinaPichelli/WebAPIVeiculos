import { Component } from '@angular/core';
import { Assistencia } from '../../models/assistencias';
import { MatDialog } from '@angular/material/dialog';
import { AssistenciaService } from '../../services/assistencia.service';

@Component({
  selector: 'app-assistencias-home',
  standalone: false,
  templateUrl: './assistencias-home.component.html',
  styleUrl: './assistencias-home.component.css'
})
export class AssistenciasHomeComponent {
  assistencias: Assistencia[] = []; 
  assistenciasGeral: Assistencia[] = []; 
  assistenciaId!: number;

  constructor(private assistenciaService: AssistenciaService, public dialog: MatDialog) { }
  ngOnInit(): void {
    
    this.assistenciaService.GetAssistencias().subscribe(data => {
      this.assistencias = data;
      this.assistenciasGeral = data;

  });
}

  // Método chamado quando a exclusão for confirmada
  onConfirmDelete(assistenciaId: number): void {
    this.assistenciaService.DeleteAssistencia(assistenciaId).subscribe({
      next: () => {
        console.log('Assistência de veículo excluído com sucesso!');
        this.assistencias = this.assistencias.filter(assistencia => assistencia.id !== assistenciaId);
      },
      error: (err) => console.error('Erro ao excluir assistência de veículo:', err)
    });
  }

  // Abre o modal de exclusão
  openDeleteModal(assistenciaId: number): void {
    this.assistenciaId = assistenciaId;
  }
}
