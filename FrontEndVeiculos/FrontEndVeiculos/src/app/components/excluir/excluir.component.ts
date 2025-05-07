import { Component, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-excluir',
  standalone: false,
  templateUrl: './excluir.component.html',
  styleUrl: './excluir.component.css'
})
export class ExcluirComponent {
  @Input() itemId: number = 0;     // ID do item a ser excluído
  @Output() confirmDelete = new EventEmitter<number>();  // Evento de confirmação

   // Fechar o modal
   closeModal(): void {
    this.itemId = 0;
  }

    // Confirmar a exclusão
    onConfirmDelete(): void {
      this.confirmDelete.emit(this.itemId);  // Emite o ID para o componente pai
      this.closeModal();  // Fecha o modal
    }
}


