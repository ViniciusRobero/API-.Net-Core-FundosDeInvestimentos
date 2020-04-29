# Fundos de Investimentos
Essa aplicação tem como objetivo criar um sistema listagem de fundos de investimentos cadastrados, aplicação e resgate desses fundos.

## Tecnologias
Para esse o desenvolvimento desse sistema, foram utilizados as tecnologias .NET Core 2.2, Entity Framework Core, Docker e com banco de dados Microsoft SQL Server 2017.

# Configurando WebAPI
A api se encontra na pasta AtivaInvestimentos.API. Para o perfeito funcionamento da mesma, as configurações abaixo devem ser efetuadas.

## Configurando a conexão do banco de dados e a API, utilizando Entity Framework Core
Dentro do arquivo ./AtivaInvestimentos.Infra/appsettings.json você pode alterar a query string de acordo com o banco de dados escolhido.

```c#
  "ConnectionStrings": {
    "SqlExpressConnection": "Server=localhost\SQLEXPRESS;Database=UsuarioDB; Integrated Security=True;"
  }
```
# Configurando o banco de dados
O banco utilizado na aplicação foi o Microsoft SQL Server 2017, porém pode ser utilizado qualquer outro banco, com as devidas alterações na query string na API e a criação dos objetos descritos abaixo. 
Você também pode gerar as tabelas automaticamente utilizando o Entity Framework Core.

## Criação de objetos para o projeto
```sql
CREATE TABLE Fundo (
	Id uniqueidentifier,
	NomeFundo varchar(300),
	CNPJFundo varchar(14),
	InvestimentoMinimo decimal,
    PRIMARY KEY (Id)
)

CREATE TABLE TipoMovimentacao(
	Id int Identity(1,1),
	Descricao varchar(10),
    PRIMARY KEY (Id)
)

-- Inserindo os tipos de movimentação 
INSERT INTO TipoMovimentacao VALUES ('Aplicação')
INSERT INTO TipoMovimentacao VALUES ('Resgate')

CREATE TABLE Movimentacao (
	Id uniqueidentifier,
	IdTipoMovimentacao int FOREIGN KEY REFERENCES TipoMovimentacao(Id),
	IdFundo uniqueidentifier FOREIGN KEY REFERENCES Fundo(Id),
	CPFCliente varchar(11),
	ValorMovimentacao decimal,
	DataMovimentacao datetime,
    PRIMARY KEY (Id)
)

--Caso queira usar alguns dados para teste, os inserts abaixo podem ajudar:
--INSERT INTO Fundo VALUES (NEWID(), 'ALASKA BLACK INSTITUCIONAL FIA', '26673556000132', 1000.00)
--INSERT INTO Fundo VALUES (NEWID(), 'ARGUCIA INCOME FIA', '07670115000132', 10000.00)

```


## Documentação do Projeto
A documentação do projeto, com as descrições do métodos, parâmetros de entrada e de saída, tipos de verbos https utilizados, você pode acessar o swagger da aplicação ao executá-la, no caminho http:\\localhost:{sua porta}\swagger.

