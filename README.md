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


https://user-images.githubusercontent.com/62727555/177458910-45634140-3897-4318-b9f5-02b20bca4f3d.mp4

- Create -> File -> Selecionar arquivo na janela que foi aberta


### Como fazer a conexão entre o meu container docker com o MySQL Workbench ?

![Conexão](https://user-images.githubusercontent.com/62727555/177453104-6887c268-2947-4caa-917d-fa12da75ab8f.png)

- Usuário: root 
- Senha: root

<p>A conexão entre o banco de dados e o MySQL Workbench deve ser feita dessa forma</p>

## Testando nossa Rest API

1. Create User - Criar usuário
    - Nessa chamada do tipo post que precisa de 2 parametros, userName e password realizando essa chamada nossa senha é criptografada e guardada no nosso banco junto com nosso userName.

    Envio:
    ```
    {
        "userName": "root",
        "password": "root"
    }
    ```

    Retorno:
    ```
    {
        "id": 1,
        "userName": "root",
        "password": "48-13-49-4D-13-7E-16-31-BB-A3-01-D5-AC-AB-6E-7B-B7-AA-74-CE-11-85-D4-56-56-5E-F5-1D-73-76-77-B2"
    }
    ```
2. Validate User - Validar usuário
    - Nessa chamada do tipo post que precisa de 2 parametros, userName e password realizando essa chamada nossas credenciais são verificadas e se estiverem corretas a api nos retorna nosso token de acesso.

    Envio:
    ```
    {
        "userName": "root",
        "password": "root"
    }
    ```

    Retorno:
    ```
    {
        "authenticated": true,
        "created": "2022-07-06 22:40:41",
        "expiration": "2022-07-06 23:40:41",
        "accessToken": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJqdGkiOiI5NzAyMWZjYTg0YzQ0M2YxOGE0YzE1ODYxYmQzMzBhMiIsInVuaXF1ZV9uYW1lIjoicm9vdCIsImlkdXNlciI6IjEiLCJleHAiOjE2NTcxNjE2NDEsImlzcyI6IkV4ZW1wbGVJc3N1ZXIiLCJhdWQiOiJFeGVtcGxlQXVkaWVuY2UifQ.EwAJOH00Os2jF6xVJAxUBZGUpmfDp_IAOC34OgUvJ24",
        "refreshToken": "ErHfHrFnoEykL5/Hg3T/K6Wxx/q2aFe48GD3Zra0PHk="
    }
    ```
3. Create CriminalCode - Criar Codigo Criminal
    - Nessa chamada do tipo post que precisa de 4 parametros no body e o accessToken tanto no queryString quanto na Header, quando concluida é criado um novo codigo penal.

    Envio:
    ```
    {
        "name": "Pedro",
        "description": "Teste",
        "penalty": 100.00,
        "prisonTime": 25
    }
    ```

    Retorno:
    ```
    {
        "id": 10,
        "name": "Pedro",
        "description": "Teste",
        "penalty": 100.00,
        "prisonTime": 25,
        "statusId": 3228,
        "createDate": "2022-07-06T22:31:11.5219215-03:00",
        "updateDate": "0001-01-01T00:00:00",
        "createUserId": 1,
        "updateUserId": 0,
        "links": [
            {
                "rel": "self",
                "href": "http://localhost:44300/api/v1/CriminalCode/10",
                "type": "application/json",
                "action": "GET"
            },
            {
                "rel": "self",
                "href": "http://localhost:44300/api/v1/CriminalCode/10",
                "type": "application/json",
                "action": "POST"
            },
            {
                "rel": "self",
                "href": "http://localhost:44300/api/v1/CriminalCode/10",
                "type": "application/json",
                "action": "PUT"
            },
            {
                "rel": "self",
                "href": "http://localhost:44300/api/v1/CriminalCode/10",
                "type": "int",
                "action": "DELETE"
            }
        ]
    }
    ```
4. CriminalCodes - Codigos Criminais
    - Essa chamada do tipo get so precisa do accessToken no Header para estar funcionando, como é uma chamada que ira nos trazer diversos dados quando o banco estiver totalmente populado, precisa estar organizada para facilicar seu leitura, por isso ela conta com o filtro de nome e paginação de seus dados.

    URL:
    ```
    http://localhost:44300/api/v1/CriminalCode/{parametro1}/{parametro2}/{parametro3}
    Exemplo: http://localhost:44300/api/v1/CriminalCode/asc/3/1

    - parametro 1: É o tipo de ordenação, variando entre asc ou desc
    - parametro 2: É o total de Codigos Criminais por pagina
    - parametro 3: É qual pagina ele ira mostrar
    ```

    Retorno:
    ```
    {
        "currentPage": 1,
        "pageSize": 3,
        "totalResults": 10,
        "sortFields": null,
        "sortDirections": "asc",
        "filters": null,
        "list": [
            {
                "id": 1,
                "name": "Gustavo",
                "description": "Teste",
                "penalty": 100.00,
                "prisonTime": 25,
                "statusId": 5139,
                "createDate": "2022-07-06T14:48:19",
                "updateDate": "0001-01-01T00:00:00",
                "createUserId": 1,
                "updateUserId": 0,
                "links": [
                    {
                        "rel": "self",
                        "href": "http://localhost:44300/api/v1/CriminalCode/1",
                        "type": "application/json",
                        "action": "GET"
                    },
                    {
                        "rel": "self",
                        "href": "http://localhost:44300/api/v1/CriminalCode/1",
                        "type": "application/json",
                        "action": "POST"
                    },
                    {
                        "rel": "self",
                        "href": "http://localhost:44300/api/v1/CriminalCode/1",
                        "type": "application/json",
                        "action": "PUT"
                    },
                    {
                        "rel": "self",
                        "href": "http://localhost:44300/api/v1/CriminalCode/1",
                        "type": "int",
                        "action": "DELETE"
                    }
                ]
            },
            {
                "id": 2,
                "name": "Gustavo",
                "description": "Teste",
                "penalty": 100.00,
                "prisonTime": 25,
                "statusId": 2436,
                "createDate": "2022-07-06T14:50:09",
                "updateDate": "0001-01-01T00:00:00",
                "createUserId": 1,
                "updateUserId": 0,
                "links": [
                    {
                        "rel": "self",
                        "href": "http://localhost:44300/api/v1/CriminalCode/2",
                        "type": "application/json",
                        "action": "GET"
                    },
                    {
                        "rel": "self",
                        "href": "http://localhost:44300/api/v1/CriminalCode/2",
                        "type": "application/json",
                        "action": "POST"
                    },
                    {
                        "rel": "self",
                        "href": "http://localhost:44300/api/v1/CriminalCode/2",
                        "type": "application/json",
                        "action": "PUT"
                    },
                    {
                        "rel": "self",
                        "href": "http://localhost:44300/api/v1/CriminalCode/2",
                        "type": "int",
                        "action": "DELETE"
                    }
                ]
            },
            {
                "id": 5,
                "name": "Isabella",
                "description": "Teste",
                "penalty": 100.00,
                "prisonTime": 25,
                "statusId": 2882,
                "createDate": "2022-07-06T22:31:00",
                "updateDate": "0001-01-01T00:00:00",
                "createUserId": 1,
                "updateUserId": 0,
                "links": [
                    {
                        "rel": "self",
                        "href": "http://localhost:44300/api/v1/CriminalCode/5",
                        "type": "application/json",
                        "action": "GET"
                    },
                    {
                        "rel": "self",
                        "href": "http://localhost:44300/api/v1/CriminalCode/5",
                        "type": "application/json",
                        "action": "POST"
                    },
                    {
                        "rel": "self",
                        "href": "http://localhost:44300/api/v1/CriminalCode/5",
                        "type": "application/json",
                        "action": "PUT"
                    },
                    {
                        "rel": "self",
                        "href": "http://localhost:44300/api/v1/CriminalCode/5",
                        "type": "int",
                        "action": "DELETE"
                    }
                ]
            }
        ]
    }
    ```

### Essas são as chamadas principais para o teste da aplicação

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
