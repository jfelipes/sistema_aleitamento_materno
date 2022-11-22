import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { HeroComponent } from './components/hero/hero.component';
import { HomeComponent } from './pages/home/home.component';
import { DataBannerComponent } from './components/data-banner/data-banner.component';
import { GradientBannerComponent } from './components/gradient-banner/gradient-banner.component';
import { PessoaComponent } from './pages/pessoa/pessoa.component';
import { PessoaRegisteringProcessComponent } from './components/pessoa-registering-process/pessoa-registering-process.component';
import { BrowserModule } from '@angular/platform-browser';
import { NgxMaskModule } from 'ngx-mask';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { PessoaListingComponent } from './components/pessoa-listing/pessoa-listing.component';
import { PessoaEditingComponent } from './components/pessoa-editing/pessoa-editing.component';
import { BancoAleitamentoComponent } from './pages/banco-aleitamento/banco-aleitamento.component';
import { BancoListingComponent } from './components/banco-listing/banco-listing.component';
import { BancoRegisteringProcessComponent } from './components/banco-registering-process/banco-registering-process.component';
import { BancoDetailingComponent } from './components/banco-detailing/banco-detailing.component';
import { EnderecoComponent } from './pages/endereco/endereco.component';
import { EstoqueComponent } from './pages/estoque/estoque.component';
import { LeiteMaternoRegisteringProcessComponent } from './components/leite-materno-registering-process/leite-materno-registering-process.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    HeroComponent,
    HomeComponent,
    DataBannerComponent,
    GradientBannerComponent,
    PessoaComponent,
    PessoaRegisteringProcessComponent,
    PessoaListingComponent,
    PessoaEditingComponent,
    BancoAleitamentoComponent,
    BancoListingComponent,
    BancoRegisteringProcessComponent,
    BancoDetailingComponent,
    EnderecoComponent,
    EstoqueComponent,
    LeiteMaternoRegisteringProcessComponent,
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
