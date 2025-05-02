# Web API de Veículos

API em **.NET** para gerenciar veículos, grupos de veículos e assistências. Utiliza **MySQL** como banco de dados.

## Funcionalidades

- Cadastro e gerenciamento de veículos, grupos de veículos e assistências.
- Persistência de dados no MySQL.

## Como Rodar

### Pré-requisitos

- **.NET 6 ou superior**.
- **MySQL**.

### Passos

1. Clone o repositório.
2. No diretório do projeto, execute:

   ```bash
   dotnet restore
   dotnet ef database update
   dotnet run
   
3. Crie o banco utilizando docker run:

<pre>
<code>
docker run --name mysql-veiculos -e MYSQL_ROOT_PASSWORD=usuario -e MYSQL_DATABASE=veiculosdatabase -e MYSQL_USER=usuario -e MYSQL_PASSWORD=123456 -p 3307:3306 -d mysql:latest
</code>
</pre>
