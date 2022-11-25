import { PessoaDTO } from './pessoaDTO';
export interface DetailAndPessoaDTO {
  showingDetail: boolean;
  editavel: boolean;
  pessoa: PessoaDTO;
}
