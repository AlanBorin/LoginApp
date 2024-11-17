# LoginApp - Sistema de Autenticação com .NET 8 e NHibernate

## 📝 Descrição
Sistema de autenticação desenvolvido em .NET 8 utilizando NHibernate como ORM e PostgreSQL como banco de dados. O sistema implementa autenticação JWT (JSON Web Token) com tempo de expiração de 1 hora.

## 🚀 Funcionalidades
- Registro de usuários
- Autenticação de usuários com JWT
- Listagem de usuários (requer autenticação)
- Hash seguro de senhas
- Token com expiração de 1 hora
- Proteção de rotas com Bearer Token

## 🛠️ Tecnologias Utilizadas
- .NET 8
- NHibernate (ORM)
- FluentNHibernate (Mapeamento)
- PostgreSQL
- JWT (JSON Web Token)
- BCrypt (Hash de senhas)
- Arquitetura MVC
- Padrão Repository
- Injeção de Dependência

## 📁 Estrutura do Projeto
LoginApp/
- ├── Controllers/
- │   └── UserController.cs
- ├── Models/
- │   └── User.cs
- ├── DTOs/
- │   ├── UserDTO.cs
- │   ├── LoginDTO.cs
- │   └── LoginResponseDTO.cs
- ├── Services/
- │   ├── UserService.cs
- │   └── TokenService.cs
- ├── Interfaces/
- │   ├── IUserRepository.cs
- │   ├── IUserService.cs
- │   └── ITokenService.cs
- ├── Persistence/
- │   ├── Mappings/
- │   │   └── UserMap.cs
- │   └── NHibernateHelper.cs
- └── Repository/
- └── UserRepository.cs

## 🔧 Configuração

### 1. Banco de Dados
Execute o script SQL abaixo no PostgreSQL:
```sql
CREATE TABLE Users (
    Id SERIAL PRIMARY KEY,
    Username VARCHAR(50) NOT NULL UNIQUE,
    Password VARCHAR(255) NOT NULL
);
```

### 2. Configuração do appsettings.json
```
{
  "Jwt": {
    "Key": "sua_chave_super_secreta_com_pelo_menos_32_caracteres",
    "Issuer": "seu_issuer",
    "Audience": "sua_audience"
  },
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=seu_banco;Username=seu_usuario;Password=sua_senha"
  }
}
```

### 3.  Instalação de Dependências
```
dotnet add package NHibernate
dotnet add package FluentNHibernate
dotnet add package Npgsql
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
dotnet add package BCrypt.Net-Next
```


# 🚀 Como Usar
1. Registro de Usuário
```
POST /api/User/register
Content-Type: application/json

{
    "username": "usuario",
    "password": "senha"
}
```

2. Login
```
POST /api/User/login
Content-Type: application/json

{
    "username": "usuario",
    "password": "senha"
}
```

3. Listar Usuários (Requer Autenticação)
```
GET /api/User/all
Authorization: Bearer seu_token_jwt
```

# 🔒 Segurança

- Senhas armazenadas com hash
- Autenticação via JWT
- Proteção contra SQL Injection via NHibernate
- Validação de dados
- Tratamento de exceções

# 📦 Requisitos

- .NET 8 SDK
- PostgreSQL
- Visual Studio 2022 ou VS Code
