import { BancoDTO } from './../../models/bancoDTO';
import { BancoService } from './../../services/banco.service';
import { Component, OnInit } from '@angular/core';
import { DetailAndBancoDTO } from 'src/app/models/detailAndBancoDTO';

@Component({
  selector: 'app-banco-listing',
  templateUrl: './banco-listing.component.html',
  styleUrls: ['./banco-listing.component.scss']
})
export class BancoListingComponent implements OnInit {
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
        alert('Banco alterada com sucesso!');
        this.changeBancoDetails(banco.id);
        this.fetchData();
      }, () => 'Não foi possível alterar o banco.'
    );
  }
}
