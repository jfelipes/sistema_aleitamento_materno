import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BancoDTO } from 'src/app/models/bancoDTO';
import { PessoaDTO } from 'src/app/models/pessoaDTO';
import { BancoService } from 'src/app/services/banco.service';
import { LeiteMaternoService } from 'src/app/services/leite-materno.service';
import { PessoaService } from 'src/app/services/pessoa.service';

@Component({
  selector: 'app-leite-materno-cadastro',
  templateUrl: './leite-materno-cadastro.component.html',
  styleUrls: ['./leite-materno-cadastro.component.scss']
})
export class LeiteMaternoCadastroComponent implements OnInit {
  leiteMaternoForm: FormGroup;
  pessoas: PessoaDTO[] = [];
  bancos: BancoDTO[] = [];

  constructor(
    private formBuilder: FormBuilder,
    private pessoaService: PessoaService,
    private bancoService: BancoService,
    private leiteService: LeiteMaternoService,
    private router: Router
  ) {
    this.leiteMaternoForm = this.formBuilder.group({
      doador: [null, Validators.compose([Validators.required])],
      banco: [null, Validators.compose([Validators.required])],
      receptor: [null],
    });
  }

  ngOnInit(): void {
    this.pessoaService.list().subscribe((response) => (this.pessoas = response));
    this.bancoService.list().subscribe((response) => (this.bancos = response));
  }

  get doador() {
    return this.leiteMaternoForm.get('doador')!;
  }

  get banco() {
    return this.leiteMaternoForm.get('banco')!;
  }

  get receptor() {
    return this.leiteMaternoForm.get('receptor')!;
  }

  saveLeiteMaterno() {
    if (this.leiteMaternoForm.invalid) return;
    this.leiteService
      .register({
        id: crypto.randomUUID(),
        disponivel: this.receptor.value != null ? false : true,
        doadorId: this.doador.value,
        bancoAleitamentoId: this.banco.value,
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
