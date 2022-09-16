# myfinance-web-netcore

MyFinance - Projeto do Curso de Pós-Graduação em Engenharia de Software da PUC-MG. Sistema de Controle de Finanças.

## Esquema Banco

Diagrama de Entidades e Relacionamentos que representa o esquema lógico do banco de dados da aplicação.

<img src='docs\diagramaer.png' alt='Diagrama de Entidades e Relacionamentos'>


## Arquitetura

O modelo arquitetural que foi utilizado para estruturar o projeto foi o MVC (Model View Controller). Foram separadas as responsabilidades em camadas, onde cada módulo tem seu papel no funcionamento do sistema.

## Como rodar

Primeiro de tudo, é importante ter instalado as seguintes dependencias:

- SQL Server 2019
- .NET6

Antes de rodar o projeto, é obrigatório criar o banco de dados e suas tabelas.
Para isso, basta conectar ao banco e executar o SQL disponível na pasta /docs (create_tables.sql).

*Importante: lembrar de configurar o ConnectionString do banco no arquivo "appsettings.json"*

Após isso, basta executar `dotnet run` na pasta principal do projeto.