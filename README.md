<h1 align="center"> Cidade Alta </h1>
<h2 align="center"> Sistema código penal Cidade Alta </h2>

## Licença
![Licença](https://img.shields.io/github/license/Vini-Dev-Py/CidadeAlta)

## Descrição do projeto 

O projeto tem como principal objetivo auxiliar e resolver o problema </br>
apresentado pelo departamento de polícia do Cidade Alta.

A polícia do Cidade Alta precisava de um sistema para controlar os </br>
códigos penais da cidade.

Por isso foi construido essa Rest API em C#, sendo o mais completa possivel </br>
e o mais simples de lidar com a mesma, para que todos consigam utilizar da melhor forma

## :blue_book: Tecnologias usadas no projeto

- C# dotnet
- ASP.NET
- JWT
- Swagger
- MySQL
- Docker e Docker-compose
- Arquivos Shell

## :hammer: Funcionalidades do projeto

- `Funcionalidade 1`: Criação de usuários.
- `Funcionalidade 2`: Autenticação de usuários.
- `Funcionalidade 3`: CRUD de código penal, Criar, Ler, atualizar e deletar códigos penais.
- `Funcionalidade 4`: CRUD de Status, Criar, Ler, atualizar e deletar Status.

## :computer: Build

>O build do projeto é bem simples, com apenas um comando podemos criar toda nossa estrutura, </br>
mas como isso é possivel ? Bom o projeto é baseado em imagens docker, ou seja, nos iniciamos o </br>
build das imagens docker e pelos comandos que estão definidos dentro dos arquivos, Dockerfile e </br>
docker-compose o banco de dados e construido e a Rest API sobe localmente, dessa forma não </br>
precisamos ter em nossa maquina local a versão do C# e nem a do MySQL que foi utilizada no projeto, </br>
assim tornando a  implementação mais rapida e facil !

## :construction_worker: Testando o projeto

### Antes de começar, precisamos do docker instalado no nosso computador

<p>Podemos fazer o download <a href="https://docs.docker.com/desktop/">aqui</a></p>

### Qual comando devemos usar para o build ?

```
docker-compose up -d --build
```

<p>No primeiro momento o build leva alguns minutos, por conta que ele esta criando os volumes e imagens pela primeira vez</p>

### Mas o que esse comando faz ?

<p>Vamos dividir ele em 3 partes</p>

- docker-compose up
- -d
- --build

<p>O docker-compose up sobe nossa aplicação, ou seja, ele é o responsavel pelo build das imagens</p>
<p>A flag -d serve para deixar nosso terminal liberado assim que o build terminar</p>
<p>Já a outra flag --build serve para ele ignorar outras versões já compiladas e compilar novamente</p>

### Ferramenta usada para os testes

- <a href="https://insomnia.rest/download">Insomnia</a>
    - O template com as chamas utilizadas no Insomnia estão <a href="https://github.com/Vini-Dev-Py/CidadeAlta/tree/main/CodigoPenalCDA/Insomnia">aqui</a>
    - Caso você nunca tenha importado um template insomnia, o próximo tópico irá ensinar
- <a href="https://www.mysql.com/products/workbench/">MySQL Workbench</a>
- <a href="http://localhost:44300/swagger/index.html">Swagger do projeto</a>
    - Lembrando o Swagger so vai funcionar assim que o projeto estiver rodando !

### Importando um template insomnia


https://user-images.githubusercontent.com/62727555/177458020-f50c092c-231f-4ca3-baeb-cca06722f3ff.mp4


### Como fazer a conexão entre o meu container docker com o MySQL Workbench ?

![Conexão](https://user-images.githubusercontent.com/62727555/177453104-6887c268-2947-4caa-917d-fa12da75ab8f.png)

- Usuário: root 
- Senha: root

<p>A conexão entre o banco de dados e o MySQL Workbench deve ser feita dessa forma</p>

### Como essas imagens são ?

- Dockerfile dotnet

![docker dotnet](https://user-images.githubusercontent.com/62727555/177453911-027bcfaf-01ae-4b52-a965-bc0b8baa5564.png)

- Dockerfile MySQL

![docker mysql](https://user-images.githubusercontent.com/62727555/177453953-a77d5c68-976e-45cf-90a2-6b197f35c517.png)

>Nesse Dockerfile primeiro definimos que usaremos a versão 5.7.22 do MySQL, depois expomos a porta 3306 do container, após isso fazemos as copias dos arquivos SQL para nossos volumes e executamos nosso arquivo shell para estarmos contruindo nosso database.

- Docker-Compose

![docker-compose](https://user-images.githubusercontent.com/62727555/177453982-3236d7ea-ad5b-496d-9e99-f83d85356436.png)

>O docker-compose é um pouco maior que os outros arquivos docker, mas é porque ele organiza os Dockerfiles, esss docker-compose ele cria dois serviços, um para nosso banco de dados e outro para nossa Rest API, configurando as senhas, usuário, database que utilizaremos na aplicação e qual seu Dockerfile responsavel por montar a imagem

### Como o banco de dados é montado ?

>Dentro do nosso projeto temos duas pastas chamadas db, uma delas é aonde guardamos o Dockerfile responsável pela imagem Mysql, que fica logo na raiz do projeto, já os arquivos SQL que determinam como nossa tabela será montada ficam na segunda pasta db que se localiza juntamente com os arquivos que compõem nossa Rest API e através desse arquivo e do arquivo shell dentro da pasta ci do projeto nosso banco é montado, pois nosso arquivo shell le e executa os comandos sql que estão dentro do arquvio
