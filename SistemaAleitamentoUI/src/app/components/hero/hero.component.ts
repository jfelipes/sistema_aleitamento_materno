import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-hero',
  templateUrl: './hero.component.html',
  styleUrls: ['./hero.component.scss']
})
export class HeroComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  listarDuvidasDoacao(): void {
    console.log("Listar dúvidas doação.");
  }

  listarDuvidasRecebimento(): void {
    console.log("Listar dúvidas recebimento.");
  }

}
