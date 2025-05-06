
import { Component } from '@angular/core';
import { Veiculo } from '../../models/veiculos';
import { Router } from '@angular/router';
import { VeiculoService } from '../../services/veiculo.service';

@Component({
  selector: 'app-cadastro-veiculo',
  standalone: false,
  templateUrl: './cadastro-veiculo.component.html',
  styleUrl: './cadastro-veiculo.component.css'
})
export class CadastroVeiculoComponent {

  btnAcao = "Cadastrar";
  btnTitulo = "Cadastrar Veículo";

  constructor(private veiculoService: VeiculoService, private router: Router) { 

  }

  createVeiculo(veiculo: Veiculo)
{
  console.log(veiculo);

  this.veiculoService.CreateVeiculo(veiculo).subscribe((data) => {
    this.router.navigate(['/veiculos-home']);
  });

//   this.veiculoService.CreateVeiculo(VeiculoService).subscribe((data) => { 
//     this.router.navigate(['/veiculo-home']);

// });
}

}
  






