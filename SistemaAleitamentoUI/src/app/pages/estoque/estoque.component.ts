import { PessoaDTO } from './../../models/pessoaDTO';
import { LeiteMaternoDTO } from './../../models/leiteMaternoDTO';
import { BancoService } from './../../services/banco.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EnderecoDTO } from 'src/app/models/enderecoDTO';
import { PessoaService } from 'src/app/services/pessoa.service';

@Component({
  selector: 'app-estoque',
  templateUrl: './estoque.component.html',
  styleUrls: ['./estoque.component.scss']
})
export class EstoqueComponent implements OnInit {
  estoque: LeiteMaternoDTO[] = [];

  constructor(
    private bancoService: BancoService,
    private pessoaService: PessoaService,
    private route: ActivatedRoute
  ) {
    this.route.params.subscribe((params) => {
      let bancoAleitamentoId = params['id'];
      this.bancoService.filter(bancoAleitamentoId).subscribe((response) => this.estoque = response.estoque);
    });
  }

  ngOnInit(): void {
  }

  getPessoaNome(pessoaId: string) {
    let nome: string = '';
    this.pessoaService.filter(pessoaId).subscribe((response) => nome = response.nome);
    return nome;
  }

}
