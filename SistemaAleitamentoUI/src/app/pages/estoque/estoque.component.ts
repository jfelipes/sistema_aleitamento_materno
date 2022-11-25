import { LeiteMaternoService } from './../../services/leite-materno.service';
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
  bancoAleitamentoId: string = '';
  estoque: LeiteMaternoDTO[] = [];
  pessoas: PessoaDTO[] = [];

  constructor(
    private bancoService: BancoService,
    private leiteService: LeiteMaternoService,
    private pessoaService: PessoaService,
    private route: ActivatedRoute
  ) {
    this.route.params.subscribe((params) => {
      let bancoAleitamentoId = params['id'];
      this.bancoAleitamentoId = bancoAleitamentoId;
    });
  }

  fetchData() {
    this.bancoService.filter(this.bancoAleitamentoId).subscribe((response) => this.estoque = response.estoque);
  }

  ngOnInit(): void {
    this.fetchData();
    this.pessoaService.list().subscribe((response) => this.pessoas = response);
  }

  getPessoaNome(pessoaId: string) {
    let nome: string = '';
    let index = this.pessoas.findIndex(pessoa => pessoa.id == pessoaId);
    return this.pessoas[index].nome;
  }

  deletarLeiteMaterno(leiteId: string) {
    this.leiteService.delete(leiteId).subscribe(() => alert('Leite Materno deletado com sucesso'))
    this.fetchData();
  }
}
