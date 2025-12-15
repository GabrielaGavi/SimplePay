# SimplePay

SimplePay é uma API REST desenvolvida em C# com ASP.NET Core que simula um sistema de pagamentos entre usuários.
A aplicação permite criar usuários, registrar transferências e atualizar saldos automaticamente, utilizando o Entity Framework Core InMemory para persistência em memória.

------------

## Tecnologias

- C# / .NET 9

- ASP.NET Core Web API

- Entity Framework Core (InMemory)

- Swagger

--------------

## Funcionalidades

- CRUD de usuários

- Registro de pagamentos entre usuários

- Documentação com Swagger

## Como executar o projeto

Pré-requisitos: .NET SDK 8.0+

1. Clone o repositório:
   ```bash
   git clone https://github.com/GabrielaGavi/SimplePay
   cd SimplePay
   ```
2. Rode o projeto
```bash
   dotnet build
   dotnet run
   ```

## Endpoints

### Usuários

| Método | Rota | Descrição |
|:--------|:------|:-----------|
| **GET** | `/api/user` | Lista todos os usuários |
| **GET** | `/api/user/{id}` | Retorna um usuário específico pelo ID |
| **POST** | `/api/user` | Cria um novo usuário |
| **PUT** | `/api/user/{id}` | Atualiza os dados de um usuário existente |
| **DELETE** | `/api/user/{id}` | Remove um usuário do sistema |

---

### Pagamentos

| Método | Rota | Descrição |
|:--------|:------|:-----------|
| **GET** | `/api/payment` | Lista todos os pagamentos registrados |
| **GET** | `/api/payment/{id}` | Retorna um pagamento específico pelo ID |
| **POST** | `/api/payment` | Cria um novo pagamento (transferência entre usuários) |
| **DELETE** | `/api/payment/{id}` | Remove um pagamento existente |
