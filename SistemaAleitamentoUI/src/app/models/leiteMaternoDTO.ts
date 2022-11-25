import { BancoDTO } from 'src/app/models/bancoDTO';
export interface LeiteMaternoDTO {
  id: string;
  disponivel: boolean;
  doadorId: string
  bancoAleitamentoId: string;
  bancoAleitamento?: BancoDTO;
  receptorId?: string;
  dataEntrada?: string;
  dataRetirada?: string;
}
