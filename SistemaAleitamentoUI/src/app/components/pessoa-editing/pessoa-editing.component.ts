import { PessoaDTO } from './../../models/pessoaDTO';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { EnderecoDTO } from 'src/app/models/enderecoDTO';

@Component({
  selector: 'app-pessoa-editing',
  templateUrl: './pessoa-editing.component.html',
  styleUrls: ['./pessoa-editing.component.scss'],
})
export class PessoaEditingComponent implements OnInit {
  pessoaId: string = crypto.randomUUID();
  pessoaForm: FormGroup;

  currentStep: number = 1;
  lastStep: number = 3;

  @Input() targetPessoa: PessoaDTO | undefined;
  @Input('editavel') isEditavel: boolean = false;
  @Output() pessoaUpdated: EventEmitter<PessoaDTO> = new EventEmitter();

  endereco(): EnderecoDTO | undefined {
    return this.targetPessoa?.endereco;
  }

  constructor(
    private formBuilder: FormBuilder
  ) {
    this.pessoaForm = this.formBuilder.group({
      nome: ['', Validators.compose([Validators.required])],
      rg: [
        '',
        Validators.compose([Validators.required, Validators.minLength(9)]),
      ],
      cpf: [
        '',
        Validators.compose([Validators.required, Validators.minLength(11)]),
      ],
      cep: [
        '',
        Validators.compose([Validators.required, Validators.minLength(8)]),
      ],
      uf: [
        '',
        Validators.compose([Validators.required, Validators.maxLength(2)]),
      ],
      localidade: ['', [Validators.required]],
      logradouro: ['', [Validators.required]],
      bairro: ['', [Validators.required]],
      numero: ['', [Validators.required]],
      complemento: [''],
    });
  }

  ngOnInit(): void {
    this.nome.setValue(this.targetPessoa?.nome);
    this.rg.setValue(this.targetPessoa?.rg);
    this.cpf.setValue(this.targetPessoa?.cpf);
    this.cep.setValue(this.targetPessoa?.endereco.cep);
    this.uf.setValue(this.targetPessoa?.endereco.uf);
    this.localidade.setValue(this.targetPessoa?.endereco.localidade);
    this.logradouro.setValue(this.targetPessoa?.endereco.logradouro);
    this.bairro.setValue(this.targetPessoa?.endereco.bairro);
    this.numero.setValue(this.targetPessoa?.endereco.numero);
    this.complemento.setValue(this.targetPessoa?.endereco.complemento);
    if (this.isEditavel === false) {
      this.pessoaForm.disable();
    }
  }

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

  registerContato(dadoContato: string) {
    if (dadoContato == '') return;
    this.targetPessoa?.contatos.push({
      id: crypto.randomUUID(),
      pessoaId: this.pessoaId,
      dado: dadoContato,
    });
  }

  turnEditable() {
    this.pessoaForm.enable();
  }

  removeContato(contatoId: string) {
    let index = this.targetPessoa?.contatos.findIndex(
      (obj) => obj.id === contatoId
    );
    this.targetPessoa?.contatos.splice(index!, 1);
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
      this.targetPessoa!.endereco = {
        id: this.targetPessoa!.endereco.id,
        cep: this.cep.value,
        uf: this.uf.value,
        localidade: this.localidade.value,
        logradouro: this.logradouro.value,
        bairro: this.bairro.value,
        numero: this.numero.value,
        complemento:
          this.complemento.value != '' ? this.complemento.value : null,
      };
    }
    this.currentStep++;
  }

  saveModifiedData() {
    this.targetPessoa!.nome = this.nome.value;
    this.targetPessoa!.rg = this.rg.value;
    this.targetPessoa!.cpf = this.cpf.value;
  }

  submit() {
    this.saveModifiedData();
    if (this.currentStep != this.lastStep) return;
    if (this.pessoaForm.invalid) {
      alert('Foram encontrados problemas na sua edição, confira os dados.')
      return;
    }
    console.log(this.targetPessoa)
    this.pessoaUpdated.emit(this.targetPessoa);
  }
}
