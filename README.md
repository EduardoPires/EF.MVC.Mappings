#EF.MVC.Mappings

Mapeamento de Entidades do Entity Framework em um Projeto ASP.NET MVC

##Objetivo

Exemplificar como trabalhar com mapeamento de entidades do Entity Framework criando relacionamentos do tipo:

* Um para Um (one-to-one)
* Um para Muitos (one-to-many)
* Muitos para Muitos (many-to-many)

Os mapeamentos foram feitos dentro de um projeto ASP.NET MVC 5 qual exibe uma View com todos os dados relacionados.

## Cenário

* Uma entidade Pessoa (base) possui derivações em outras duas entidades (PessoaFisica e PessoaJuridica)
* A classe Pessoa possui informações em comum entre PessoaFisica e PessoaJuridica
* As classes PessoaFisica e PessoaJuridica possuem uma lista da entidade Endereco

### Mapeamento

* Entidade Pessoa possui relacionamento (one-to-one) com PessoaFisica
* Entidade Pessoa possui relacionamento (one-to-many) com PessoaJuridica
* Entidades PessoaFisica e PessoaJuridica possuem relacionamento (many-to-many) com Endereco

### Detalhes

* O mapeamento foi feito utilizando Fluent API em classes de configuração isoladas
* É feito um insert de dados Fake gerando todo o relacionamento
* Existe uma consulta de todos os dados relacionados (Eager Load)
* Existe uma Controller Home e uma View Index exibindo todos os dados da consulta

## Feedback

Entre em <a href="http://www.eduardopires.net.br/" target="_blank">contato</a> para enviar seu feedback

Eduardo Pires - Microsoft MVP ASP.NET


