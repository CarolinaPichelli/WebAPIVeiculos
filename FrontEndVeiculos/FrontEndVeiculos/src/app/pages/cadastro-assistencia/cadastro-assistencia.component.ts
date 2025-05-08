import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AssistenciaService } from '../../services/assistencia.service';
import { Assistencia } from '../../models/assistencias';

@Component({
  selector: 'app-cadastro-assistencia',
  standalone: false,
  templateUrl: './cadastro-assistencia.component.html',
  styleUrl: './cadastro-assistencia.component.css'
})
export class CadastroAssistenciaComponent {

  btnAcao = "Cadastrar";
  btnTitulo = "Cadastrar Assistência de veículo";

  constructor(private assistenciaService: AssistenciaService, private router: Router) {}

  createAssistencia(assistencia: Assistencia)
{
  this.assistenciaService.CreateAssistencia(assistencia).subscribe((data) => {
    this.router.navigate(['/assistencias-home']);
  });
}

}



