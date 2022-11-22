import { BancoDTO } from 'src/app/models/bancoDTO';
import { BancoService } from './../../services/banco.service';
import { PessoaService } from 'src/app/services/pessoa.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-data-banner',
  templateUrl: './data-banner.component.html',
  styleUrls: ['./data-banner.component.scss']
})
export class DataBannerComponent implements OnInit {
  quantidadePessoasAptasBeneficio: number = 0;
  quantidadeBancosdeAleitamento: number = 0;
  quantidadeMovimentacoes: number = 0;
  bancos: BancoDTO[] = [];

  constructor(private pessoaService: PessoaService, private bancoService: BancoService) {
    this.pessoaService.list().subscribe((response) => this.quantidadePessoasAptasBeneficio = response.length);
    this.bancoService.list().subscribe((response) => {
      this.bancos = response;
      this.quantidadeBancosdeAleitamento = this.bancos.length;
      this.bancos.forEach(banco => this.quantidadeMovimentacoes += banco.estoque.length);
    });
  }

  ngOnInit(): void {
  }

}
