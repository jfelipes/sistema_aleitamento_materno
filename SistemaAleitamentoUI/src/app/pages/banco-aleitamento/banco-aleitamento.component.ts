import { Component, OnInit } from '@angular/core';
import { BancoDTO } from 'src/app/models/bancoDTO';
import { DetailAndBancoDTO } from 'src/app/models/detailAndBancoDTO';
import { BancoService } from 'src/app/services/banco.service';

@Component({
  selector: 'app-banco-aleitamento',
  templateUrl: './banco-aleitamento.component.html',
  styleUrls: ['./banco-aleitamento.component.scss']
})
export class BancoAleitamentoComponent implements OnInit {
  bancosData: DetailAndBancoDTO[] = [];
  filteredBancosData: DetailAndBancoDTO[] = [];
  lastReceivedFilter: string = '';

  fetchData() {
    this.bancosData = [];
    this.bancoService
      .list()
      .subscribe((response) =>
        response.forEach((data) =>
          this.bancosData.push({ showingDetail: false, banco: data })
        )
      );
    this.filterBanco(this.lastReceivedFilter);
  }

  filterBanco(filter: any) {
    if (filter == null || filter == undefined || filter == '') {
      this.filteredBancosData = this.bancosData;
      return;
    }
    if (typeof filter === 'string') {
      this.lastReceivedFilter = filter.toLowerCase();
    } else {
      this.lastReceivedFilter = filter.target.value.toLowerCase();
    }
    this.filteredBancosData = this.bancosData.filter((bancoData) =>
      bancoData.banco.nome.toLowerCase().includes(this.lastReceivedFilter)
    );
  }

  constructor(private bancoService: BancoService) {
    this.fetchData();
  }

  ngOnInit(): void {}

  changeBancoDetails(bancoId: string) {
    let index = this.bancosData.findIndex(
      (data) => data.banco.id === bancoId
    );
    this.bancosData[index].showingDetail =
      !this.bancosData[index].showingDetail;
  }

  deleteBanco(bancoId: string) {
    this.bancoService.delete(bancoId).subscribe(
      () => {
        alert('Banco deletado com sucesso!');
        this.fetchData();
      },
      () => alert('Não foi possível deletar o banco em questão.')
    );
  }

  saveBanco(banco: BancoDTO) {
    let index = this.filteredBancosData.findIndex(data => data.banco.id == banco.id);
    this.bancoService.update(banco).subscribe(
      () => {
        alert('Banco alterado com sucesso!');
        this.changeBancoDetails(banco.id);
        this.fetchData();
      }, () => 'Não foi possível alterar o banco.'
    );
  }
}
