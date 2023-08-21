# Estudos C#

### Projeto para estudos de C# (.NET)

Criação de API, seguindo padrões e boas práticas, com Docker e workflow para o Github Actions (build e testes).</br>
O que foi utlizado neste projeto:
- API Rest;
- DDD;
- EF e SQL Server;
- Testes (xUnit);
- Repository Pattern;
- Dependency Injection Pattern;
- Docker compose;
- Github actions.

## Execute a API

    1. Coloque o projeto "docker-compose" como "Set as Startup Project";
    2. Execute com "Docker Compose".
    (necessário ter o Docker instalado)
## API Rest

`GET /api/clientes`
</br>(Retorna todos os Clientes)

<details>
<summary>Response</summary>
```json
    [
        {
            "id": 0,
            "nomeCompleto": "Nome Completo",
            "telefone": "(99) 99999-9999",
            "email": "email@email.com",
            "endereco": "Rua Tal"
        }
    ]
```
</details>
</br>

`GET /api/clientes/nomes`
</br>(Retorna todos os Nomes dos Clientes)

<details>
<summary>Response</summary>
```json
    [
        {
            "id": 0,
            "nomeCompleto": "Nome Completo
        }
    ]
```
</details>
</br>

`GET /api/clientes/{id}`
</br>(Retorna Cliente por Id)

<details>
<summary>Response</summary>
```json
    {
        "id": 0,
        "nomeCompleto": "Nome Completo",
        "telefone": "(99) 99999-9999",
        "email": "email@email.com",
        "endereco": "Rua Tal"
    }
```
</details>
</br>

`POST /api/clientes`
</br>(Cria novo Cliente)

<details>
<summary>Request</summary>
```json
    {
        "nomeCompleto": "Nome Completo",
        "telefone": "(99) 99999-9999",
        "email": "email@email.com",
        "endereco": "Rua Tal"
    }
```
</details>
<details>
<summary>Response</summary>
```json
    {
        "id": 0,
        "nomeCompleto": "Nome Completo",
        "telefone": "(99) 99999-9999",
        "email": "email@email.com",
        "endereco": "Rua Tal"
    }
```
</details>
</br>

`PUT /api/clientes/{id}`
</br>(Modifica Cliente existente)

<details>
<summary>Request</summary>
```json
    {
        "nomeCompleto": "Nome Completo",
        "telefone": "(99) 99999-9999",
        "email": "email@email.com",
        "endereco": "Rua Tal"
    }
```
</details>
<details>
<summary>Response</summary>
```json
    {
        "id": 0,
        "nomeCompleto": "Nome Completo",
        "telefone": "(99) 99999-9999",
        "email": "email@email.com",
        "endereco": "Rua Tal"
    }
```
</details>
</br>

`DELETE /api/clientes/{id}`
</br>(Remove Cliente existente)

## Materiais utilizados

<p align="center">
        <img src="https://miro.medium.com/v2/resize:fit:720/format:webp/0*3LCl6RxN9cyYyl8z.jpeg" width="400px">
</p>
<p align="center">
    <span style="font-size: 12px; text-align: center; width: 100%">Fonte: Implementando na prática Rest API com conceitos de DDD + .NET CORE + SQL no Docker + IoC -[Parte Técnica]</br>
(https://medium.com/beelabacademy/implementando-na-pr%C3%A1tica-rest-api-com-conceitos-de-ddd-net-2160291a44b7)
    </span>
</p>
</br>

<details>
<summary>Implementando na prática Rest API com conceitos de DDD + .NET CORE + SQL no Docker + IoC -[Parte Técnica]</summary>
https://medium.com/beelabacademy/implementando-na-pr%C3%A1tica-rest-api-com-conceitos-de-ddd-net-2160291a44b7
</details>
<details>
<summary>Repository Pattern Implementation in ASP.NET Core</summary>
https://medium.com/net-core/repository-pattern-implementation-in-asp-net-core-21e01c6664d7
</details>
<details>
<summary>The Most Used Design Patterns in .NET Development</summary>
https://medium.com/@gustavorestani/the-most-used-design-patterns-in-net-development-80d76f9fb6b
</details>
<details>
<summary>How to containerize your ASP.NET Core application and SQL Server with Docker</summary>
https://www.twilio.com/blog/containerize-your-aspdotnet-core-application-and-sql-server-with-docker
</details>
<details>
<summary>Building and testing .NET</summary>
https://docs.github.com/en/actions/automating-builds-and-tests/building-and-testing-net
</details>
<details>
<summary>Testing Validation Attributes with xUnit</summary>
https://www.codeproject.com/Tips/5268823/Testing-Validation-Attributes-with-xUnit
</details>
<details>
<summary>FluentValidation</summary>
https://docs.fluentvalidation.net/en/latest/index.html
</details>
<details>
<summary>Writing Unit Test for Model Validation</summary>
https://bytelanguage.com/2020/07/31/writing-unit-test-for-model-validation/
</details>
<details>
<summary>Shared Context between Tests</summary>
https://xunit.net/docs/shared-context
</details>
<details>
<summary>Unit testing ASP.NET Core Web API</summary>
https://www.damirscorner.com/blog/posts/20220805-UnitTestingAspNetCoreWebApi.html
</details>
<details>
<summary>Além do Fact com xUnit</summary>
https://medium.com/thiagobarradas/alem-do-fact-com-xunit-dotnet-6a52b69a50d2
</details>
<details>
<summary>CRUD API Design & CRUD API Recommendations</summary>
https://blog.stoplight.io/crud-api-design
</details>
<details>
<summary>Playlist - Microservices - Macoratti</summary>
https://www.youtube.com/playlist?list=PLJ4k1IC8GhW24-nppbX0n0OE3DBGhsYEs
</details>
<details>
<summary>Vídeo - .NET Docker Tutorial - SQL Server Docker [.NET Docker]</summary>
https://www.youtube.com/watch?v=hpLvXNASyTI
</details>
<details>
<summary>Vídeo - GitHub Actions for Beginners</summary>
https://www.youtube.com/watch?v=hoN9r86D72U
</details>
</br>