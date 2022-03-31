# Finansist

A API do FinanSist tem como objetivo possibilitar que as interfaces (FrontEnd e Mobile) possam
interagir de forma simples e compacta.

## Autores

- [@GabrielRodriguesDev](https://github.com/GabrielRodriguesDev)

## Documentação

[Documentação](https://link-da-documentação)

## Stack utilizada

**Back-end:** .NET, MySQL

## Usado por

Esse projeto é destinado a qualquer pessoa que deseje controlar suas finanças pessoais.

## Aprendizados

Utilização de CQRS com .NET, utilização do ORM Entity Framework com transações gerenciadas de forma manual, e utilização do Dapper. Implementação de auth com JWT e padrões de seguraça e arquiteturas, seguindo os padrões de SOLID e modelando seguindo os principios do DDD.

## Melhorias

1 - Auth - JWT com utilização de Coockies e Signalr  
2 - Log's em Bancos de dados separados, implementando o ElastickSearch e Kibana para observabilidade

## Docker

docker build --no-cache -t gabrielrodriguesdev/finansist:latest .
docker run -d -p 5000:80 --name finansist gabrielrodriguesdev/finansist

docker run -d --name mysql -p 7000:3306 -e MYSQL_ROOT_PASSWORD=fx870 -e bind-address:0.0.0.0 -e MYSQL_ROOT_HOST=% mysql:5.7

{
"email": "administrador@finansist.com.br",
"senha": "Fx@870Fx@870"
}
