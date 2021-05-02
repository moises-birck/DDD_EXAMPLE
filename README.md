# DDD_EXAMPLE

Projeto criado com .Net core, versão 3.1

Para executar, deve-se acessar a solution
~\DDD_EXAMPLE\DDD_EXAMPLE.sln

Configurar uma base sql server
Acessar arquivo:
~\DDD_EXAMPLE\Infrastructure\Configuration\ContextBase.cs
	Metódo GetStringConectionConfig()
		Adicionar string de conexão com SQL SERVER

Selecionar o projeto API, dentro dá pasta "1 - presentation" e compilar para ter acesso a mesma, com swagger
As validações pedidas no desafio, foi feito na camada de testes
	Testes: Abrir a camada "6 - Testes", clicar em cima dá classe "CalculateValues.cs" com o botão direito e depois clicar em "run tests"
	
Estrutura 
 
 -Base de dados, sendo criada automaticamente pela aplicação.
	"Create DataBase and Tables"
	"Inserts" em tabelas
 
 -DDD
	-CRUD DDD_web, para adicionar produtos, alterar e etc.
	-API, com as funcionalidades pedidas
		(adicionei o swagger para facilitar a visualização dos métodos)
	OBS (As Entidades estão fora do domínio, pois se precisar usar as mesmas em outro projeto futuro, não precisa referenciar o domínio obrigatoriamente)
 
 -Fiz também uma sistema WEB, com apenas um CRUD dá lista de DDD, pra conseguir mostrar o uso de classes genéricas e de reaproveitavendo de código.
 
 
 
	