import { EnderecoDTO } from './../../models/enderecoDTO';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EnderecoService } from 'src/app/services/endereco.service';

@Component({
  selector: 'app-endereco',
  templateUrl: './endereco.component.html',
  styleUrls: ['./endereco.component.scss'],
})
export class EnderecoComponent implements OnInit {
  endereco: EnderecoDTO | undefined;

  constructor(
    private enderecoService: EnderecoService,
    private route: ActivatedRoute
  ) {
    this.route.params.subscribe((params) => {
      let enderecoId = params['id'];
      this.enderecoService
        .filter(enderecoId)
        .subscribe((response) => (this.endereco = response));
    });
  }

  ngOnInit(): void {}
}
