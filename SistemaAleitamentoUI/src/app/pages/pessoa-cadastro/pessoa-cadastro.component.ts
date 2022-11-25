import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ContatoDTO } from 'src/app/models/contatoDTO';
import { EnderecoDTO } from 'src/app/models/enderecoDTO';
import { EnderecoService } from 'src/app/services/endereco.service';
import { PessoaService } from 'src/app/services/pessoa.service';

@Component({
  selector: 'app-pessoa-cadastro',
  templateUrl: './pessoa-cadastro.component.html',
  styleUrls: ['./pessoa-cadastro.component.scss']
})
export class PessoaCadastroComponent implements OnInit {
  pessoaId: string = crypto.randomUUID();
  pessoaForm: FormGroup;
  endereco: EnderecoDTO | undefined;
  contatoList: ContatoDTO[] = [];
  filledBasedOnCep: boolean = false;

  currentStep: number = 1;
  lastStep: number = 3;

  constructor(
    private formBuilder: FormBuilder,
    private pessoaService: PessoaService,
    private enderecoService: EnderecoService,
    private router: Router
  ) {
    this.pessoaForm = this.formBuilder.group({
      nome: ['', Validators.compose([Validators.required])],
      rg: ['', Validators.compose([Validators.required, Validators.minLength(9)])],
      cpf: ['', Validators.compose([Validators.required, Validators.minLength(11)])],
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
    return this.pessoaForm.get('nome')!;
  }

  get rg() {
    return this.pessoaForm.get('rg')!;
  }

  get cpf() {
    return this.pessoaForm.get('cpf')!;
  }

  get cep() {
    return this.pessoaForm.get('cep')!;
  }

  get uf() {
    return this.pessoaForm.get('uf')!;
  }

  get localidade() {
    return this.pessoaForm.get('localidade')!;
  }

  get logradouro() {
    return this.pessoaForm.get('logradouro')!;
  }

  get bairro() {
    return this.pessoaForm.get('bairro')!;
  }

  get numero() {
    return this.pessoaForm.get('numero')!;
  }

  get complemento() {
    return this.pessoaForm.get('complemento')!;
  }

  validateCep() {
    if (this.cep.errors) return;
    if (this.filledBasedOnCep) return;
    // Fill form based on cep, using outside api
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

  registerContato(dadoContato: string) {
    if (dadoContato == '') return;
    this.contatoList.push({
      id: crypto.randomUUID(),
      pessoaId: this.pessoaId,
      dado: dadoContato,
    });
  }

  removeContato(contatoId: string) {
    let index = this.contatoList.findIndex((obj) => obj.id === contatoId);
    this.contatoList.splice(index, 1);
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
        this.rg.value === '' ||
        this.cpf.value === ''
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
    if (this.currentStep >= 2) {
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
    }
    this.currentStep++;
  }

  submit() {
    if (this.currentStep != this.lastStep) return;
    if (this.pessoaForm.invalid) return;
    let registryOutput = {
      ...this.pessoaForm.value,
      id: this.pessoaId,
      endereco: this.endereco,
      enderecoId: this.endereco!.id,
      contatos: this.contatoList,
    };
    this.pessoaService.register(registryOutput).subscribe(
      () => {
        this.router.navigate(['']);
        alert('Pessoa cadastrada com sucesso!');
      },
      () => alert('Erro: Não foi possível realizar o cadastro.')
    );
  }
}
