import { EstoqueComponent } from './pages/estoque/estoque.component';
import { EnderecoComponent } from './pages/endereco/endereco.component';
import { BancoAleitamentoComponent } from './pages/banco-aleitamento/banco-aleitamento.component';
import { PessoaComponent } from './pages/pessoa/pessoa.component';
import { HomeComponent } from './pages/home/home.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: "", component: HomeComponent },
  { path: "pessoa", component: PessoaComponent },
  { path: "banco", component: BancoAleitamentoComponent },
  { path: "endereco/:id", component: EnderecoComponent },
  { path: "estoque/:id", component: EstoqueComponent },
  { path  : "**", redirectTo: "", pathMatch: "full" }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
