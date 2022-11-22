import { EnderecoDTO } from './enderecoDTO';
import { LeiteMaternoDTO } from './leiteMaternoDTO';
export interface BancoDTO {
  id: string;
  nome: string;
  responsavelId: string;
  endereco: EnderecoDTO;
  enderecoId: string;
  estoque: LeiteMaternoDTO[];
}
