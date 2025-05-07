import { Component } from '@angular/core';
import { Plano } from '../../models/planos';
import { Router } from '@angular/router';
import { PlanoService } from '../../services/plano.service';

@Component({
  selector: 'app-cadastro-plano',
  standalone: false,
  templateUrl: './cadastro-plano.component.html',
  styleUrl: './cadastro-plano.component.css'
})
export class CadastroPlanoComponent {

  btnAcao = "Cadastrar";
  btnTitulo = "Cadastrar Plano";

  constructor(private planoService: PlanoService, private router: Router) { }

  createPlano(plano: Plano){
    console.log(plano);
  
    this.planoService.CreatePlano(plano).subscribe((data) => {
      this.router.navigate(['/planos-home']);
    });
  
  }

}







 









