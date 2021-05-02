# DDD_EXAMPLE

Projeto criado com .Net core, versão 3.1

Para executar, deve-se acessar a solution
~\DDD_EXAMPLE\DDD_EXAMPLE.sln

Configurar uma base sql server
~\DDD_EXAMPLE\Infrastructure\Configuration\ContextBase.cs
	Metódo GetStringConectionConfig()
		Adicionar string de conexão com SQL SERVER

Selecionar o projeto API, dentro dá pasta "1 - presentation"

Estrutura 
 
 -Base de dados, sendo criada automaticamente pela aplicação.
 
 -DDD
	-CRUD DDD_web, para adicionar produtos, alterar e etc.
	-API, com as funcionalidades pedidas
		(adicionar o swagger para facilitar a visualização dos métodos)
	OBS (As Entidades estão fora do domínio, pois se precisar as mesmas em outro projeto futuro não precisa referenciar o domínio obrigatoriamente)
	
 
	