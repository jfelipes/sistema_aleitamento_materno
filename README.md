## Aplicação (API) para Minimizar Problemas na Saúde Pública Relacionados com Aleitamento Materno.

> Tornar possível o aleitamento materno para: mães com problemas de lactação, pais solteiros, prisões, orfanatos, hospitais, entre outros.

Essa aplicação tornará possível a interligação entre **lactantes doadoras** e possíveis **receptores**. Permitindo o contato entre esses e também o agendamento de visitas para coletas e/ou remoções em suas próprias casas, ou bancos, ampliando cada vez mais esse direito. Interligação entre bancos de leite para atender um maior número de necessitados.

#### Front-End:

O front-end conta com um visual minimalista produzido em Angular juntamente com scss.

##### Instruções de uso:

- Você deve ter o <a href="https://docs.docker.com/get-docker/">Docker</a> e o <a href="https://docs.docker.com/compose/install/">Docker Compose</a> Instalado em sua máquina.
- Como o projeto está totalmente dockerizado, para sua utilização, é necessário repetir os seguintes comandos:
```
git clone https://github.com/yJFelipeSS/sistema_aleitamento_materno.git
cd sistema_aleitamento_materno
docker compose  up -d --build
docker compose -f '...[path_do_arquivo]/sistema_aleitamento_materno/docker-compose.yml'  -p 'sistema_aleitamento_materno' start
```
