import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { HeroComponent } from './components/hero/hero.component';
import { HomeComponent } from './pages/home/home.component';
import { DataBannerComponent } from './components/data-banner/data-banner.component';
import { GradientBannerComponent } from './components/gradient-banner/gradient-banner.component';
import { PessoaComponent } from './pages/pessoa/pessoa.component';
import { BrowserModule } from '@angular/platform-browser';
import { NgxMaskModule } from 'ngx-mask';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { PessoaEditingComponent } from './components/pessoa-editing/pessoa-editing.component';
import { BancoAleitamentoComponent } from './pages/banco-aleitamento/banco-aleitamento.component';
import { BancoDetailingComponent } from './components/banco-detailing/banco-detailing.component';
import { EnderecoComponent } from './pages/endereco/endereco.component';
import { EstoqueComponent } from './pages/estoque/estoque.component';
import { AcoesComponent } from './pages/acoes/acoes.component';
import { PessoaCadastroComponent } from './pages/pessoa-cadastro/pessoa-cadastro.component';
import { BancoAleitamentoCadastroComponent } from './pages/banco-aleitamento-cadastro/banco-aleitamento-cadastro.component';
import { LeiteMaternoCadastroComponent } from './pages/leite-materno-cadastro/leite-materno-cadastro.component';
import { AgendamentoCadastroComponent } from './pages/agendamento-cadastro/agendamento-cadastro.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    HeroComponent,
    HomeComponent,
    DataBannerComponent,
    GradientBannerComponent,
    PessoaComponent,
    PessoaEditingComponent,
    BancoAleitamentoComponent,
    BancoDetailingComponent,
    EnderecoComponent,
    EstoqueComponent,
    AcoesComponent,
    PessoaCadastroComponent,
    BancoAleitamentoCadastroComponent,
    LeiteMaternoCadastroComponent,
    AgendamentoCadastroComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    NgxMaskModule.forRoot()
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
