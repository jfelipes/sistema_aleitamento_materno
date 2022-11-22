import { LeiteMaternoDTO } from './../models/leiteMaternoDTO';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class LeiteMaternoService {

  constructor(private http: HttpClient) { }

  retrieveDataFromOutsideCepApi(cep: string) {
    return this.http.
      get<LeiteMaternoDTO>(`${environment.apiCep}/${cep}/json`);
  }

  register(leite: LeiteMaternoDTO) {
    return this.http.post<LeiteMaternoDTO>(`${environment.apiBase}/leitematerno`, leite);
  }

  list() {
    return this.http.get<LeiteMaternoDTO[]>(`${environment.apiBase}/leitematerno`);
  }

  filter(leiteId: string) {
    return this.http.get<LeiteMaternoDTO>(`${environment.apiBase}/leitematerno/${leiteId}`);
  }

}
