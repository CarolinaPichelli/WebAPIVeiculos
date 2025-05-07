import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { EmpresaService } from '../../services/empresa.service';
import { Empresa } from '../../models/empresas';

@Component({
  selector: 'app-cadastro-empresa',
  standalone: false,
  templateUrl: './cadastro-empresa.component.html',
  styleUrl: './cadastro-empresa.component.css'
})
export class CadastroEmpresaComponent {
  btnAcao = "Cadastrar";
  btnTitulo = "Cadastrar Empresa";

  constructor(private empresaService: EmpresaService, private router: Router) { }

  createEmpresa(empresa: Empresa)
  {
    console.log(empresa);
  
    this.empresaService.CreateEmpresa(empresa).subscribe((data) => {
      this.router.navigate(['/empresas-home']);
    });
  }
}







