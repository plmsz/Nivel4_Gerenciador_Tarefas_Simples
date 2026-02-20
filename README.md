# 📋 Simple Task Manager API

API REST para gerenciamento de tarefas desenvolvida em C# .NET com arquitetura em camadas, aplicando boas práticas de separação de responsabilidades.

## 🎯 Objetivo

Criar uma API REST completa para gerenciar tarefas (CRUD), com validações robustas e arquitetura limpa separando:
- **Camada de Comunicação** (Controllers)
- **Camada de Regras de Negócio** (Services e UseCases)

---

## 🚀 Tecnologias Utilizadas

- **.NET 8.0** (ou superior)
- **ASP.NET Core Web API**
- **Swagger/OpenAPI** para documentação
- **Arquitetura em Camadas**
- **Injeção de Dependência**

---

## 📁 Estrutura do Projeto

```
Nivel4_Gerenciador_Tarefas_Simples/
│
├── SimpleTaskManager.API/              # Camada de Apresentação
│   ├── Controllers/
│   │   └── TaskController.cs          # Endpoints da API
│   ├── Program.cs                      # Configuração da aplicação
│   └── appsettings.json
│
├── SimpleTaskManager.Application/      # Camada de Aplicação
│   └── UseCases/
│       └── Task/
│           ├── PostTask.cs            # Criar tarefa
│           ├── GetAllTasks.cs         # Listar todas as tarefas
│           ├── GetByIdTask.cs         # Buscar tarefa por ID
│           ├── UpdateTask.cs          # Atualizar tarefa
│           └── DeleteTask.cs          # Excluir tarefa
│
└── Communication/                      # Camada de Comunicação
    ├── Entity/
    │   └── Task.cs                    # Modelo de dados
    ├── Enum/
    │   ├── Priority.cs                # Enum de prioridades
    │   └── Status.cs                  # Enum de status
    ├── Requests/
    │   └── RequestTaskJson.cs         # DTO de requisição
    ├── Responses/
    │   ├── ResponseTaskJson.cs        # DTO de resposta
    │   └── ResponseAllTasksJson.cs    # DTO de lista de tarefas
    ├── Services/
    │   └── TaskService.cs             # Validações de negócio
    └── Repository/
        └── Repository.cs              # Repositório em memória
```

---

## 📊 Modelo de Dados

### Task (Tarefa)

| Campo | Tipo | Obrigatório | Restrições |
|-------|------|-------------|------------|
| `id` | GUID | Sim | Gerado automaticamente; único para cada tarefa |
| `name` | string | Sim | Máximo de 100 caracteres |
| `description` | string | Não | Máximo de 500 caracteres |
| `priority` | enum | Sim | `Low`, `Medium` ou `High` |
| `dueDate` | DateTime | Sim | Data futura para conclusão da tarefa (apenas na criação) |
| `status` | enum | Sim | `Pending`, `InProgress` ou `Completed` |

### Enums

**Priority (Prioridade):**
```csharp
public enum Priority
{
    Low,      // Baixa prioridade
    Medium,   // Média prioridade
    High      // Alta prioridade
}
```

**Status:**
```csharp
public enum Status
{
    Pending,     // Pendente
    InProgress,  // Em progresso
    Completed    // Concluída
}
```

---

## 🔌 Endpoints da API

### Base URL
```
https://localhost:{porta}/api/tasks
```

### 1. Criar Tarefa
```http
POST /api/tasks
Content-Type: application/json

{
  "name": "Implementar autenticação",
  "description": "Adicionar JWT ao projeto",
  "priority": 2,
  "dueDate": "2026-03-01T10:00:00",
  "status": 0
}
```

**Respostas:**
- `201 Created` - Tarefa criada com sucesso
- `400 Bad Request` - Dados inválidos

---

### 2. Listar Todas as Tarefas
```http
GET /api/tasks
```

**Respostas:**
- `200 OK` - Lista de tarefas
- `204 No Content` - Nenhuma tarefa encontrada

---

### 3. Buscar Tarefa por ID
```http
GET /api/tasks/{id}
```

**Respostas:**
- `200 OK` - Tarefa encontrada
- `404 Not Found` - Tarefa não encontrada

---

### 4. Atualizar Tarefa
```http
PUT /api/tasks/{id}
Content-Type: application/json

{
  "name": "Implementar autenticação JWT",
  "description": "Adicionar JWT ao projeto com refresh token",
  "priority": 2,
  "dueDate": "2026-03-01T10:00:00",
  "status": 1
}
```

**Respostas:**
- `200 OK` - Tarefa atualizada
- `400 Bad Request` - Dados inválidos
- `404 Not Found` - Tarefa não encontrada

---

### 5. Excluir Tarefa
```http
DELETE /api/tasks/{id}
```

**Respostas:**
- `204 No Content` - Tarefa excluída
- `404 Not Found` - Tarefa não encontrada

---

## ✅ Regras de Validação

### Criação (POST)
1. ✅ **Name** é obrigatório e deve ter no máximo 100 caracteres
2. ✅ **Description** deve ter no máximo 500 caracteres (opcional)
3. ✅ **Priority** deve ser um valor válido do enum (0 = Low, 1 = Medium, 2 = High)
4. ✅ **Status** deve ser um valor válido do enum (0 = Pending, 1 = InProgress, 2 = Completed)
5. ✅ **DueDate** não pode ser uma data no passado

### Atualização (PUT)
1. ✅ **Name** é obrigatório e deve ter no máximo 100 caracteres
2. ✅ **Description** deve ter no máximo 500 caracteres (opcional)
3. ✅ **Priority** deve ser um valor válido do enum
4. ✅ **Status** deve ser um valor válido do enum
5. ⚠️ **DueDate** pode ser qualquer data (não valida data passada na atualização)

---

## 🛠️ Como Executar o Projeto

### Pré-requisitos
- .NET SDK 8.0 ou superior
- Visual Studio Code ou Visual Studio 2022

### Passos

1. **Clone ou baixe o projeto**
   ```bash
   cd "./Nivel4_Gerenciador_Tarefas_Simples"
   ```

2. **Restaurar dependências**
   ```bash
   cd SimpleTaskManager.API
   dotnet restore
   ```

3. **Compilar o projeto**
   ```bash
   dotnet build
   ```

4. **Executar a aplicação**
   ```bash
   dotnet run
   ```

5. **Acessar o Swagger**
   ```
   https://localhost:{porta}/swagger
   ```
   (A porta será exibida no console ao executar o projeto)

---

## 📝 Exemplos de Uso

### Criar uma tarefa
```bash
curl -X POST "https://localhost:7000/api/tasks" \
  -H "Content-Type: application/json" \
  -d '{
    "name": "Estudar Clean Architecture",
    "description": "Ler livro e implementar exemplos",
    "priority": 2,
    "dueDate": "2026-03-15T18:00:00",
    "status": 0
  }'
```

### Listar todas as tarefas
```bash
curl -X GET "https://localhost:7000/api/tasks"
```

### Buscar tarefa específica
```bash
curl -X GET "https://localhost:7000/api/tasks/{id}"
```

### Atualizar tarefa
```bash
curl -X PUT "https://localhost:7000/api/tasks/{id}" \
  -H "Content-Type: application/json" \
  -d '{
    "name": "Estudar Clean Architecture",
    "description": "Concluído o livro, agora implementar no projeto",
    "priority": 2,
    "dueDate": "2026-03-15T18:00:00",
    "status": 2
  }'
```

### Excluir tarefa
```bash
curl -X DELETE "https://localhost:7000/api/tasks/{id}"
```

---

## 🏗️ Arquitetura

### Camadas do Projeto

```
┌─────────────────────────────────────────┐
│         TaskController (API)            │  ← Camada de Apresentação
│  (Recebe requisições HTTP)              │
└─────────────────┬───────────────────────┘
                  │
                  ▼
┌─────────────────────────────────────────┐
│           TaskService                   │  ← Camada de Negócio
│  (Validações e regras de negócio)      │
└─────────────────┬───────────────────────┘
                  │
                  ▼
┌─────────────────────────────────────────┐
│           UseCases                      │  ← Camada de Aplicação
│  (Casos de uso específicos)            │
└─────────────────┬───────────────────────┘
                  │
                  ▼
┌─────────────────────────────────────────┐
│           Repository                    │  ← Camada de Dados
│  (Armazenamento em memória)            │
└─────────────────────────────────────────┘
```

### Princípios Aplicados

- ✅ **Separação de Responsabilidades (SoC)**
- ✅ **Injeção de Dependência (DI)**
- ✅ **Single Responsibility Principle (SRP)**
- ✅ **DTOs para comunicação entre camadas**
- ✅ **Validações centralizadas no Service**

---

## 📊 Status Codes Utilizados

| Código | Descrição | Quando é usado |
|--------|-----------|----------------|
| `200 OK` | Sucesso | GET e PUT com sucesso |
| `201 Created` | Recurso criado | POST com sucesso |
| `204 No Content` | Sem conteúdo | DELETE com sucesso ou GET sem resultados |
| `400 Bad Request` | Requisição inválida | Dados de entrada inválidos |
| `404 Not Found` | Não encontrado | Tarefa não existe |

---

## ⚙️ Configuração

### Program.cs

```csharp
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<Repository>();
builder.Services.AddSingleton<TaskService>();
```

**Nota:** O projeto usa `Singleton` para o repositório, mantendo dados em memória durante a execução. Em produção, isso seria substituído por um banco de dados real.

---

## 🧪 Testando a API

### Via Swagger
1. Execute o projeto
2. Acesse `https://localhost:{porta}/swagger`
3. Teste cada endpoint diretamente pela interface

### Via Postman
Importe a collection usando a URL do Swagger:
```
https://localhost:{porta}/swagger/v1/swagger.json
```

### Via cURL
Use os exemplos fornecidos na seção "Exemplos de Uso"

---

## 🔍 Validação de Requisitos

| Requisito | Status |
|-----------|--------|
| API inicia sem erros | ✅ |
| Swagger expõe os endpoints | ✅ |
| Criar tarefas com campos obrigatórios | ✅ |
| Listar todas as tarefas | ✅ |
| Buscar tarefa por ID | ✅ |
| Atualizar tarefa existente | ✅ |
| Excluir tarefa por ID | ✅ |
| Nome obrigatório (máx 100 caracteres) | ✅ |
| Description (máx 500 caracteres) | ✅ |
| Data limite não pode ser passado na criação | ✅ |
| Priority e Status aceita apenas valores válidos | ✅ |
| Arquitetura em camadas | ✅ |
| Status codes apropriados | ✅ |

---

## 📚 Próximas Melhorias

- [ ] Implementar persistência com Entity Framework Core
- [ ] Adicionar autenticação e autorização (JWT)
- [ ] Implementar paginação na listagem
- [ ] Adicionar filtros (por status, prioridade, data)
- [ ] Implementar testes unitários
- [ ] Adicionar logging
- [ ] Implementar versionamento da API
- [ ] Docker containerization

---

Desenvolvido como parte do desafio **Rocket C# - Nível 4: Gerenciador de Tarefas Simples**

---

## 📄 Licença

Este projeto é parte de um desafio educacional e está disponível para fins de aprendizado.

---

## 🤝 Contribuições

Sugestões e melhorias são bem-vindas! Sinta-se livre para:
1. Fazer um fork do projeto
2. Criar uma branch para sua feature (`git checkout -b feature/MinhaFeature`)
3. Commit suas mudanças (`git commit -m 'Adiciona MinhaFeature'`)
4. Push para a branch (`git push origin feature/MinhaFeature`)
5. Abrir um Pull Request
