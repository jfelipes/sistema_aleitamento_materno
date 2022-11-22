import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-banco-aleitamento',
  templateUrl: './banco-aleitamento.component.html',
  styleUrls: ['./banco-aleitamento.component.scss']
})
export class BancoAleitamentoComponent implements OnInit {
  registryProcess: boolean = false;
  registryLeiteProcess: boolean = false;

  constructor() { }

  ngOnInit(): void {
  }

  startRegisteringProcess() {
    this.registryProcess = true;
  }

  startLeiteRegisteringProcess() {
    this.registryLeiteProcess = true;
  }

  stopRegisteringProcess() {
    this.registryProcess = false;
    this.registryLeiteProcess = false;
  }
}
