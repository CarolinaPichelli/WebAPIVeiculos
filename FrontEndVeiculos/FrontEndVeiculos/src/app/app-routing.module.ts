import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { VeiculosHomeComponent } from './pages/veiculos-home/veiculos-home.component';
import { HomeComponent } from './pages/home/home.component';
import { FormVeiculosComponent } from './components/form-veiculos/form-veiculos.component';
import { CadastroVeiculoComponent } from './pages/cadastro-veiculo/cadastro-veiculo.component';

const routes: Routes = [
  {path: "", component:HomeComponent},
  {path: "veiculos-home", component:VeiculosHomeComponent},
  {path: "cadastro-veiculo", component:CadastroVeiculoComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
