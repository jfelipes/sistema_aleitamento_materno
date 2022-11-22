import { BancoDTO } from 'src/app/models/bancoDTO';
export interface LeiteMaternoDTO {
  disponivel: boolean;
  doadorId: string
  bancoAleitamentoId: string;
  bancoAleitamento?: BancoDTO;
  receptorId?: string;
  dataEntrada?: string;
  dataRetirada?: string;
}
