import { PessoaDTO } from './../models/pessoaDTO';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PessoaService {

  constructor(private http: HttpClient) { }

  register(pessoa: PessoaDTO) {
    return this.http.post<PessoaDTO>(`${environment.apiBase}/pessoa`, pessoa);
  }

  filter(pessoaId: string) {
    return this.http.get<PessoaDTO>(`${environment.apiBase}/pessoa/${pessoaId}`)
  }

  delete(pessoaId: string) {
    return this.http.delete(`${environment.apiBase}/pessoa/${pessoaId}`);
  }

  update(pessoa: PessoaDTO) {
    return this.http.put<PessoaDTO>(`${environment.apiBase}/pessoa`, pessoa);
  }

  list() {
    return this.http.get<PessoaDTO[]>(`${environment.apiBase}/pessoa`);
  }
}
