import { ContatoDTO } from './contatoDTO';
import { EnderecoDTO } from 'src/app/models/enderecoDTO';

export interface PessoaDTO {
  id: string;
  nome: string;
  rg: string;
  cpf: string;
  endereco: EnderecoDTO;
  enderecoId: string;
  contatos: ContatoDTO[];
}
