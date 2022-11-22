export interface EnderecoDTO {
  id: string;
  cep: string;
  uf: string;
  localidade: string;
  logradouro: string;
  bairro: string;
  numero: string;
  complemento?: string;
}
