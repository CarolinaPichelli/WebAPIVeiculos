import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { GrupoService } from '../../services/grupo.service';
import { Grupo } from '../../models/grupos';

@Component({
  selector: 'app-cadastro-grupo',
  standalone: false,
  templateUrl: './cadastro-grupo.component.html',
  styleUrl: './cadastro-grupo.component.css'
})
export class CadastroGrupoComponent {
  btnAcao = "Cadastrar";
  btnTitulo = "Cadastrar Grupo";

   
  constructor(private grupoService: GrupoService, private router: Router) { }

  createGrupo(grupo: Grupo)
  {
    console.log(grupo);
  
    this.grupoService.CreateGrupo(grupo).subscribe((data) => {
      this.router.navigate(['/grupos-home']);
    });
  }
}
