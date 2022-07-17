# Patrimônio PS

[![CircleCI](https://circleci.com/gh/adolfosp/Back-PatrimonioDev.svg?style=svg&circle-token=20a665b5da536a4849089b6d94f5c02c9aba6356)](https://github.com/adolfosp/Back-PatrimonioDev/tree/main)

## Introdução

> Esse é um projeto realizado para o gerenciamento de patrimônios voltado à equipamentos tecnológicos da empresa. O projeto foi desenvolvido com intuito de facilitar o gerenciamento dos equipamentos disponibilizados pelas empresa para os seus funcionários.

## Tecnologias utilizadas
 
<img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/csharp/csharp-original.svg" alt="csharp" width="40" height="40"/> </a>
 <a href="https://dotnet.microsoft.com/" target="_blank"> <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/dot-net/dot-net-original-wordmark.svg" alt="dotnet" width="40" height="40"/> </a> <a href="https://git-scm.com/" target="_blank"> <img src="https://www.vectorlogo.zone/logos/git-scm/git-scm-icon.svg" alt="git" width="40" height="40"/> </a> 
<a href="https://www.microsoft.com/en-us/sql-server" target="_blank"> <img src="https://www.svgrepo.com/show/303229/microsoft-sql-server-logo.svg" alt="mssql" width="40" height="40"/> </a></p>

## Como rodar a aplicação

- Baixe o projeto
```
git clone https://github.com/adolfosp/Back-PatrimonioDev.git
```
- Depois altere a connection string do SQL SERVER para a sua instância

![image](https://user-images.githubusercontent.com/39220517/162618546-bdb8884b-1776-4a9a-8e63-e7c82d5296cf.png)

- Logo após realizar esses passos, abra o terminal pelo VISUAL STUDIO ou IDE preferida e digite o comando:
```
 Add-Migration addTabelas -p Persistence -s PatrimonioDev
```
- Esse comando irá criar as tabelas de acordo com as minhas models 

- E por fim digite
```
Update-Database
```
- Será executado as tabelas criadas pelo comando anterior no nosso banco

- Espero que tenha dado tudo certo. A partir de agora você vai poder testar a aplicação

