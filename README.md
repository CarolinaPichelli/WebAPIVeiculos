# Web API de Veículos

API em **.NET** para gerenciar veículos, grupos de veículos, empresas, planos e assistências. Utiliza **MySQL** como banco de dados.

## Funcionalidades

- CRUD de veículos, grupos de veículos, empresas, planos e assistências.
- Persistência de dados no MySQL.

## Como Rodar

### Pré-requisitos

- **.NET 6 ou superior**.
- **MySQL**.
- **Node.js**.
- **Angular CLI** (instalar com `npm install -g @angular/cli`).

### Passos

1. Clone o repositório.
2. No diretório do projeto, execute:

   ```bash
   dotnet restore
   dotnet ef database update
   dotnet run
   
3. Crie o banco utilizando docker run:

<pre>
<code>docker run --name mysql-veiculos -e MYSQL_ROOT_PASSWORD=usuario -e MYSQL_DATABASE=veiculosdatabase -e MYSQL_USER=usuario -e MYSQL_PASSWORD=123456 -p 3307:3306 -d mysql:latest</code>
</pre>

4. No diretório do front-end, executar no terminal:
<pre>
<code>npm install <br>
ng serve</code>
</pre>

Após isso, você poderá acessar a aplicação localmente!
