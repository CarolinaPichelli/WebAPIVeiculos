import { Component, OnInit } from '@angular/core';
import { VeiculoService } from '../../services/veiculo.service';
import { Veiculo } from '../../models/veiculos';
import { Grupo } from '../../models/grupos';
import { GrupoService } from '../../services/grupo.service';
import { EmpresaService } from '../../services/empresa.service';
import { Empresa } from '../../models/empresas';
import { Plano } from '../../models/planos';
import { PlanoService } from '../../services/plano.service';

@Component({
  selector: 'app-home',
  standalone: false,
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit{

  veiculos: Veiculo[] = [];
  veiculosGeral : Veiculo[] = [];

  grupos: Grupo[] = [];
  gruposGeral : Grupo[] = [];

  empresas: Empresa[] = [];
  empresasGeral : Empresa[] = [];

  planos: Plano[] = [];
  planosGeral : Plano[] = [];

  constructor (private veiculoService : VeiculoService, private grupoService : GrupoService,
    private empresaService : EmpresaService, private planoService : PlanoService
  ) {}

  ngOnInit() : void {
    this.veiculoService.GetVeiculos().subscribe(data => {
      this.veiculos = data;
      this.veiculosGeral = data;
    }) 

      this.grupoService.GetGrupos().subscribe(data => {
        this.grupos = data;
        this.gruposGeral = data;
    }) 

    this.empresaService.GetEmpresas().subscribe(data => {
      this.empresas = data;
      this.empresasGeral = data;
    }) 
      this.planoService.GetPlanos().subscribe(data => {
        this.planos = data;
        this.planosGeral = data;
  }) 
  }
}
