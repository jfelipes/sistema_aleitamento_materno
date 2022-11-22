import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { BancoDTO } from '../models/bancoDTO';

@Injectable({
  providedIn: 'root'
})
export class BancoService {

  constructor(private http: HttpClient) { }

  register(banco: BancoDTO) {
    return this.http.post<BancoDTO>(`${environment.apiBase}/bancoaleitamento`, banco);
  }

  filter(bancoId: string) {
    return this.http.get<BancoDTO>(`${environment.apiBase}/bancoaleitamento/${bancoId}`);
  }

  delete(bancoId: string) {
    return this.http.delete(`${environment.apiBase}/bancoaleitamento/${bancoId}`);
  }

  update(banco: BancoDTO) {
    return this.http.put<BancoDTO>(`${environment.apiBase}/bancoaleitamento`, banco);
  }

  list() {
    return this.http.get<BancoDTO[]>(`${environment.apiBase}/bancoaleitamento`);
  }
}
