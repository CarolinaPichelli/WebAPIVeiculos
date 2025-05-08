import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Empresa } from '../../models/empresas';
import { EmpresaService } from '../../services/empresa.service';

@Component({
  selector: 'app-empresas-home',
  standalone: false,
  templateUrl: './empresas-home.component.html',
  styleUrl: './empresas-home.component.css'
})
export class EmpresasHomeComponent {
  empresas: Empresa[] = []; 
  empresasGeral: Empresa[] = []; 
  empresaId!: number;

  constructor(private empresaService: EmpresaService, public dialog: MatDialog) { }

  ngOnInit(): void {
    
    this.empresaService.GetEmpresas().subscribe(data => {
    this.empresas = data;
    this.empresasGeral = data;

  });

}
 // Método chamado quando a exclusão for confirmada
 onConfirmDelete(empresaId: number): void {
  this.empresaService.DeleteEmpresa(this.empresaId).subscribe({
    next: () => {
      console.log('Empresa excluída com sucesso!');
      this.empresas = this.empresas.filter(grupo => grupo.id !== this.empresaId);
    },
    error: (err) => console.error('Erro ao excluir empresa:', err)
  });
}

// Abre o modal de exclusão
openDeleteModal(empresaId: number): void {
  this.empresaId = empresaId;
}
}

  

