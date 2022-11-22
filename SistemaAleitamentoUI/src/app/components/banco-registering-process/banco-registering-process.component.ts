import { LeiteMaternoDTO } from './../../models/leiteMaternoDTO';
import { PessoaDTO } from './../../models/pessoaDTO';
import { BancoService } from './../../services/banco.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ContatoDTO } from 'src/app/models/contatoDTO';
import { EnderecoDTO } from 'src/app/models/enderecoDTO';
import { EnderecoService } from 'src/app/services/endereco.service';
import { PessoaService } from 'src/app/services/pessoa.service';

@Component({
  selector: 'app-banco-registering-process',
  templateUrl: './banco-registering-process.component.html',
  styleUrls: ['./banco-registering-process.component.scss']
})
export class BancoRegisteringProcessComponent implements OnInit {
  bancoId: string = crypto.randomUUID();
  bancoForm: FormGroup;
  endereco: EnderecoDTO | undefined;
  pessoas: PessoaDTO[] = [];
  selectedPessoa: PessoaDTO | undefined;
  selectedPessoaFlag: boolean = false;
  contatoList: ContatoDTO[] = [];
  filledBasedOnCep: boolean = false;

  currentStep: number = 1;
  lastStep: number = 2;

  constructor(
    private formBuilder: FormBuilder,
    private bancoService: BancoService,
    private enderecoService: EnderecoService,
    private pessoaService: PessoaService,
    private router: Router
  ) {
    pessoaService.list().subscribe((response) => this.pessoas = response);
    this.bancoForm = this.formBuilder.group({
      nome: ['', Validators.compose([Validators.required])],
      cep: ['', Validators.compose([Validators.required, Validators.minLength(8)])],
      uf: ['', Validators.compose([Validators.required, Validators.maxLength(2)])],
      localidade: ['', [Validators.required]],
      logradouro: ['', [Validators.required]],
      bairro: ['', [Validators.required]],
      numero: ['', [Validators.required]],
      complemento: [''],
    });
  }

  ngOnInit(): void {}

  get nome() {
    return this.bancoForm.get('nome')!;
  }

  get cep() {
    return this.bancoForm.get('cep')!;
  }

  get uf() {
    return this.bancoForm.get('uf')!;
  }

  get localidade() {
    return this.bancoForm.get('localidade')!;
  }

  get logradouro() {
    return this.bancoForm.get('logradouro')!;
  }

  get bairro() {
    return this.bancoForm.get('bairro')!;
  }

  get numero() {
    return this.bancoForm.get('numero')!;
  }

  get complemento() {
    return this.bancoForm.get('complemento')!;
  }

  selectPessoa(event: any) {
    let pessoas = this.pessoas.filter(x => x.nome === event.target.value);
    if (pessoas.length == 0) return;
    let pessoa = this.pessoas.filter(x => x.nome === event.target.value)[0];
    this.selectedPessoa = pessoa;
    this.selectedPessoaFlag = true;
  }

  validateCep() {
    if (this.cep.errors) return;
    if (this.filledBasedOnCep) return;
    this.enderecoService
      .retrieveDataFromOutsideCepApi(this.cep.value)
      .subscribe(
        (response: EnderecoDTO) => {
          this.cep.setValue(response.cep.replace('-', ''));
          this.uf.setValue(response.uf);
          this.localidade.setValue(response.localidade);
          this.logradouro.setValue(response.logradouro);
          this.bairro.setValue(response.bairro);
          this.numero.setValue(response.numero);
          this.filledBasedOnCep = true;
        },
        () => {
          this.cep.setErrors({
            ...this.cep.errors,
            invalid_cep: true,
          });
        }
      );
  }

  previousStep() {
    if (this.currentStep === 0) return;
    this.currentStep--;
  }

  nextStep() {
    if (this.currentStep == this.lastStep) return;
    if (this.currentStep == 1) {
      if (
        this.nome.value === '' ||
        this.selectedPessoaFlag == false
      )
        return;
    } else if (this.currentStep == 2) {
      if (
        this.cep.value === '' ||
        this.uf.value === '' ||
        this.localidade.value === '' ||
        this.logradouro.value === '' ||
        this.bairro.value === '' ||
        this.numero.value === ''
      )
        return;
    }
    this.currentStep++;
  }

  submit() {
    this.endereco = {
      id: crypto.randomUUID(),
      cep: this.cep.value,
      uf: this.uf.value,
      localidade: this.localidade.value,
      logradouro: this.logradouro.value,
      bairro: this.bairro.value,
      numero: this.numero.value,
      complemento: this.complemento.value != "" ? this.complemento.value : null
    };
    if (this.currentStep != this.lastStep) return;
    if (this.bancoForm.invalid) return;
    let registryOutput = {
      id: this.bancoId,
      nome: this.nome.value,
      responsavelId: this.selectedPessoa!.id,
      enderecoId: this.endereco.id,
      endereco: this.endereco,
      estoque: [],
    };
    this.bancoService.register(registryOutput).subscribe(
      () => {
        this.router.navigate(['']);
        alert('Banco cadastrado com sucesso!');
      },
      () => alert('Erro: Não foi possível realizar o cadastro.')
    );
    console.log(registryOutput)
  }
}
