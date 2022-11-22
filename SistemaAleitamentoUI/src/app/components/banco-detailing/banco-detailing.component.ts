import { Router } from '@angular/router';
import { PessoaDTO } from './../../models/pessoaDTO';
import { PessoaService } from './../../services/pessoa.service';
import { BancoService } from './../../services/banco.service';
import { Component, Input, OnInit } from '@angular/core';
import { BancoDTO } from 'src/app/models/bancoDTO';

@Component({
  selector: 'app-banco-detailing',
  templateUrl: './banco-detailing.component.html',
  styleUrls: ['./banco-detailing.component.scss']
})
export class BancoDetailingComponent implements OnInit {
  responsavel!: PessoaDTO;
  @Input() bancoData!: BancoDTO;

  constructor(private bancoService: BancoService, private pessoaService: PessoaService, private route: Router) {
  }

  ngOnInit(): void {
    this.pessoaService.filter(this.bancoData!.responsavelId).subscribe((response) => this.responsavel = response)
  }

  goToEnderecoDetailingPage() {
    this.route.navigate([`endereco/${this.bancoData.enderecoId}`])
  }

  goToEstoqueDetailingPage() {
    this.route.navigate([`estoque/${this.bancoData.id}`])
  }
}
