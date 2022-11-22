import { Router } from '@angular/router';
import { BancoService } from './../../services/banco.service';
import { BancoDTO } from './../../models/bancoDTO';
import { LeiteMaternoService } from './../../services/leite-materno.service';
import { PessoaService } from 'src/app/services/pessoa.service';
import { Component, OnInit } from '@angular/core';
import { PessoaDTO } from 'src/app/models/pessoaDTO';

@Component({
  selector: 'app-leite-materno-registering-process',
  templateUrl: './leite-materno-registering-process.component.html',
  styleUrls: ['./leite-materno-registering-process.component.scss'],
})
export class LeiteMaternoRegisteringProcessComponent implements OnInit {
  pessoas: PessoaDTO[] = [];
  bancos: BancoDTO[] = [];
  selectedDoador: PessoaDTO | undefined;
  selectedDoadorFlag: boolean = false;
  selectedBanco: BancoDTO | undefined;
  selectedBancoFlag: boolean = false;
  selectedReceptor: PessoaDTO | undefined;

  constructor(
    private pessoaService: PessoaService,
    private bancoService: BancoService,
    private leiteService: LeiteMaternoService,
    private router: Router
  ) {
    pessoaService.list().subscribe((response) => (this.pessoas = response));
    bancoService.list().subscribe((response) => (this.bancos = response));
  }

  ngOnInit(): void {}

  selectDoador(event: any) {
    let pessoas = this.pessoas.filter((x) => x.nome === event.target.value);
    if (pessoas.length == 0) return;
    let pessoa = this.pessoas.filter((x) => x.nome === event.target.value)[0];
    this.selectedDoador = pessoa;
    this.selectedDoadorFlag = true;
  }

  selectReceptor(event: any) {
    let pessoas = this.pessoas.filter((x) => x.nome === event.target.value);
    if (pessoas.length == 0) return;
    let pessoa = this.pessoas.filter((x) => x.nome === event.target.value)[0];
    this.selectedReceptor = pessoa;
  }

  selectBancoAleitamento(event: any) {
    let bancos = this.bancos.filter((x) => x.nome === event.target.value);
    if (bancos.length == 0) return;
    let banco = this.bancos.filter((x) => x.nome === event.target.value)[0];
    this.selectedBanco = banco;
    this.selectedBancoFlag = true;
  }

  saveLeiteMaterno() {
    if (this.selectBancoAleitamento == null || this.selectDoador == null) {
      alert('Você deve preencher todos campos obrigatórios!');
      return;
    }
    let alternativeInfo =
      this.selectedReceptor != null
        ? { receptorId: this.selectedReceptor?.id }
        : {};

    this.leiteService
      .register({
        disponivel: this.selectedReceptor != null ? false : true,
        doadorId: this.selectedDoador!.id,
        bancoAleitamentoId: this.selectedBanco!.id,
        ...alternativeInfo,
      })
      .subscribe(
        () => {
          alert('Leite Materno cadastrado com sucesso!');
          this.router.navigate(['']);
        },
        () => alert('Não foi possível cadastrar o leite materno.')
      );
  }
}
