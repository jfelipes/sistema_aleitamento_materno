import { EnderecoDTO } from 'src/app/models/enderecoDTO';
import { HttpClient } from '@angular/common/http';
import { environment } from './../../environments/environment';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class EnderecoService {

  constructor(private http: HttpClient) { }

  retrieveDataFromOutsideCepApi(cep: string) {
    return this.http.
      get<EnderecoDTO>(`${environment.apiCep}/${cep}/json`);
  }

  register(endereco: EnderecoDTO) {
    return this.http.post<EnderecoDTO>(`${environment.apiBase}/endereco`, endereco);
  }

  list() {
    return this.http.get<EnderecoDTO[]>(`${environment.apiBase}/endereco`);
  }

  filter(enderecoId: string) {
    return this.http.get<EnderecoDTO>(`${environment.apiBase}/endereco/${enderecoId}`);
  }

}
