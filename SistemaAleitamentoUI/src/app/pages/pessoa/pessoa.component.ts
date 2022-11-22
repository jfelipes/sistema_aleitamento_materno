import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-pessoa',
  templateUrl: './pessoa.component.html',
  styleUrls: ['./pessoa.component.scss']
})
export class PessoaComponent implements OnInit {
  registryProcess: boolean = false;

  constructor() { }

  ngOnInit(): void {
  }

  startRegisteringProcess() {
    this.registryProcess = true;
  }

  stopRegisteringProcess() {
    this.registryProcess = false;
  }

}
