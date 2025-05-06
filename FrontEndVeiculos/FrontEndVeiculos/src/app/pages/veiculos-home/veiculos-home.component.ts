import { Component, OnInit } from '@angular/core';
import { VeiculoService } from '../../services/veiculo.service'; // Corrigido o nome para UserService
import { Veiculo } from '../../models/veiculos';
import { MatDialog } from '@angular/material/dialog';
// import { ExcluirComponent } from '../../componentes/excluir/excluir.component';

@Component({
  selector: 'app-veiculos-home',
  standalone: false,
  templateUrl: './veiculos-home.component.html',
  styleUrl: './veiculos-home.component.css'
})
export class VeiculosHomeComponent {
  veiculos: Veiculo[] = []; 
  veiculosGeral: Veiculo[] = []; 

  constructor(private veiculoService: VeiculoService, public dialog: MatDialog) { 
    // Inicializa o array de usuários

  }
  ngOnInit(): void {
    
    this.veiculoService.GetVeiculos().subscribe(data => {
      this.veiculos = data;
      this.veiculosGeral = data;

  })

}
}




// search(event: Event): void {
//   const target = event.target as HTMLInputElement;
//   const value = target.value.toLowerCase(); // converte valor para lowercase

//   this.usuarios = this.usuarioGeral.filter(usuario => {  
//     return usuario.nome.toLowerCase().includes(value) || usuario.email.toLowerCase().includes(value) ; // faz comparação em lowercase
//   });
// }

// OpenDialog(id : number){
//   this.dialog.open(ExcluirComponent, {
//     width: '350px', 
//     height: '350px',
//     data: {id: id}, 
//   });
  
// }
// }
