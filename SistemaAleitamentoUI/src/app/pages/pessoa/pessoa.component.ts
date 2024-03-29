import { Component, OnInit } from '@angular/core';
import { DetailAndPessoaDTO } from 'src/app/models/detailAndPessoaDTO';
import { PessoaDTO } from 'src/app/models/pessoaDTO';
import { PessoaService } from 'src/app/services/pessoa.service';

@Component({
  selector: 'app-pessoa',
  templateUrl: './pessoa.component.html',
  styleUrls: ['./pessoa.component.scss']
})
export class PessoaComponent implements OnInit {
  pessoasData: DetailAndPessoaDTO[] = [];
  filteredPessoasData: DetailAndPessoaDTO[] = [];
  lastReceivedFilter: string = '';

  fetchData() {
    this.pessoasData = [];
    this.pessoaService
      .list()
      .subscribe((response) =>
        response.forEach((data) =>
          this.pessoasData.push({ showingDetail: false, editavel: false, pessoa: data })
        )
      );
    this.filterPeople(this.lastReceivedFilter);
  }

  filterPeople(filter: any) {
    if (filter == null || filter == undefined || filter == '') {
      this.filteredPessoasData = this.pessoasData;
      return;
    }
    if (typeof filter === 'string') {
      this.lastReceivedFilter = filter.toLowerCase();
    } else {
      this.lastReceivedFilter = filter.target.value.toLowerCase();
    }
    this.filteredPessoasData = this.pessoasData.filter((pessoaData) =>
      pessoaData.pessoa.nome.toLowerCase().includes(this.lastReceivedFilter)
    );
  }

  constructor(private pessoaService: PessoaService) {
    this.fetchData();
  }

  ngOnInit(): void {}

  changePessoaDetails(pessoaId: string, editavel: boolean = false) {
    let index = this.pessoasData.findIndex(
      (data) => data.pessoa.id === pessoaId
    );
    this.pessoasData[index] = {
      ...this.pessoasData[index],
      editavel: this.pessoasData[index].showingDetail === false ? editavel : false,
      showingDetail: !this.pessoasData[index].showingDetail,
    }
  }

  deletePessoa(pessoaId: string) {
    this.pessoaService.delete(pessoaId).subscribe(
      () => {
        alert('Pessoa deletada com sucesso!');
        this.fetchData();
      },
      () => alert('Não foi possível deletar a pessoa em questão.')
    );
  }

  savePessoa(pessoa: PessoaDTO) {
    let index = this.filteredPessoasData.findIndex(data => data.pessoa.id == pessoa.id);
    this.pessoaService.update(pessoa).subscribe(
      () => {
        alert('Pessoa alterada com sucesso!');
        // this.filteredPessoasData[index].pessoa = pessoa;
        this.changePessoaDetails(pessoa.id);
        this.fetchData();
      }, () => 'Não foi possível alterar a pessoa.'
    );
  }
}
