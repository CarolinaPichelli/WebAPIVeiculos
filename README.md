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
