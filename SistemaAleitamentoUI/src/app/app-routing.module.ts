import { AgendamentoCadastroComponent } from './pages/agendamento-cadastro/agendamento-cadastro.component';
import { LeiteMaternoCadastroComponent } from './pages/leite-materno-cadastro/leite-materno-cadastro.component';
import { BancoAleitamentoCadastroComponent } from './pages/banco-aleitamento-cadastro/banco-aleitamento-cadastro.component';
import { PessoaCadastroComponent } from './pages/pessoa-cadastro/pessoa-cadastro.component';
import { AcoesComponent } from './pages/acoes/acoes.component';
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
  { path: "pessoa/cadastro", component: PessoaCadastroComponent },
  { path: "banco", component: BancoAleitamentoComponent },
  { path: "banco/cadastro", component: BancoAleitamentoCadastroComponent },
  { path: "leite-materno/cadastro", component: LeiteMaternoCadastroComponent },
  { path: "agendamento/cadastro", component: AgendamentoCadastroComponent },
  { path: "acoes", component: AcoesComponent },
  { path: "endereco/:id", component: EnderecoComponent },
  { path: "estoque/:id", component: EstoqueComponent },
  { path  : "**", redirectTo: "", pathMatch: "full" }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
