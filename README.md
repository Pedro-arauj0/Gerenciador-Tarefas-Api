# 📋 API Gerenciador de Tarefas

API RESTful desenvolvida com **ASP.NET Core 9.0** e **Entity Framework Core** para gerenciamento de tarefas, permitindo organizar e controlar suas atividades diárias de forma eficiente.

## 🎯 Sobre o Projeto

Este projeto foi desenvolvido como parte do desafio da **Digital Innovation One (DIO)** da trilha .NET, aplicando conceitos modernos de desenvolvimento backend com **Minimal APIs**, **Entity Framework Core** e boas práticas de arquitetura de software.

---

## 🚀 Tecnologias Utilizadas

- **[.NET 9.0](https://dotnet.microsoft.com/)** - Framework principal
- **[ASP.NET Core Minimal APIs](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis)** - Arquitetura simplificada de endpoints
- **[Entity Framework Core 9.0](https://learn.microsoft.com/en-us/ef/core/)** - ORM para persistência de dados
- **[SQLite](https://www.sqlite.org/)** - Banco de dados leve e eficiente
- **[Swagger/OpenAPI](https://swagger.io/)** - Documentação interativa da API
- **[C# 12](https://learn.microsoft.com/en-us/dotnet/csharp/)** - Linguagem de programação

---

## 📂 Estrutura do Projeto
```
GerenciadorTarefas/
├── Models/              # Entidades do domínio
│   └── Tarefa.cs
├── DTOs/                # Data Transfer Objects
│   └── TarefaDTO.cs
├── Data/                # Contexto do banco de dados
│   └── AppDbContext.cs
├── Enums/               # Enumerações
│   └── StatusTarefa.cs
├── Program.cs           # Configuração da aplicação e endpoints
└── appsettings.json     # Configurações da aplicação
```

---

## ⚙️ Funcionalidades

### Endpoints Disponíveis

| Método | Endpoint | Descrição |
|--------|----------|-----------|
| `GET` | `/` | Mensagem de boas-vindas da API |
| `GET` | `/tarefas` | Lista todas as tarefas |
| `GET` | `/tarefas/{id}` | Busca uma tarefa específica por ID |
| `GET` | `/tarefas/status/{status}` | Filtra tarefas por status |
| `POST` | `/tarefas` | Cria uma nova tarefa |
| `PUT` | `/tarefas/{id}` | Atualiza uma tarefa completamente |
| `PATCH` | `/tarefas/{id}/status` | Atualiza apenas o status da tarefa |
| `DELETE` | `/tarefas/{id}` | Remove uma tarefa |

### Status Disponíveis

- `Pendente` - Tarefa ainda não iniciada
- `EmAndamento` - Tarefa em execução
- `Concluida` - Tarefa finalizada

---

## 🔧 Como Executar o Projeto

### Pré-requisitos

- [.NET SDK 9.0](https://dotnet.microsoft.com/download) ou superior
- Editor de código (VS Code, Visual Studio, Rider)
- [Git](https://git-scm.com/) (para clonar o repositório)

### Passos para execução

1. **Clone o repositório:**
```bash
git clone https://github.com/Pedro-arauj0/gerenciador-tarefas-api.git
cd gerenciador-tarefas-api
```

2. **Restaure as dependências:**
```bash
dotnet restore
```

3. **Execute a aplicação:**
```bash
dotnet run
```

4. **Acesse a documentação Swagger:**
```
http://localhost:5274/swagger
```

---

## 📬 Exemplos de Uso

### Criar uma nova tarefa

**Requisição:**
```http
POST /tarefas
Content-Type: application/json

{
  "titulo": "Estudar Entity Framework",
  "descricao": "Revisar conceitos de migrations e relacionamentos",
  "status": "Pendente"
}
```

**Resposta:**
```json
{
  "id": 1,
  "titulo": "Estudar Entity Framework",
  "descricao": "Revisar conceitos de migrations e relacionamentos",
  "dataCriacao": "2024-12-01T10:30:00",
  "dataConclusao": null,
  "status": "Pendente"
}
```

### Listar todas as tarefas

**Requisição:**
```http
GET /tarefas
```

**Resposta:**
```json
[
  {
    "id": 1,
    "titulo": "Estudar Entity Framework",
    "descricao": "Revisar conceitos de migrations e relacionamentos",
    "dataCriacao": "2024-12-01T10:30:00",
    "dataConclusao": null,
    "status": "Pendente"
  }
]
```

### Atualizar status de uma tarefa

**Requisição:**
```http
PATCH /tarefas/1/status?novoStatus=Concluida
```

**Resposta:**
```json
{
  "id": 1,
  "titulo": "Estudar Entity Framework",
  "descricao": "Revisar conceitos de migrations e relacionamentos",
  "dataCriacao": "2024-12-01T10:30:00",
  "dataConclusao": "2024-12-01T15:45:00",
  "status": "Concluida"
}
```

---

## 🗃️ Banco de Dados

O projeto utiliza **SQLite** como banco de dados, que é criado automaticamente na primeira execução da aplicação. O arquivo do banco (`tarefas.db`) é gerado na raiz do projeto.

### Schema da tabela Tarefas

| Campo | Tipo | Descrição |
|-------|------|-----------|
| `Id` | INTEGER | Identificador único (chave primária) |
| `Titulo` | TEXT | Título da tarefa (obrigatório) |
| `Descricao` | TEXT | Descrição detalhada (opcional) |
| `DataCriacao` | DATETIME | Data de criação da tarefa |
| `DataConclusao` | DATETIME | Data de conclusão (preenchida automaticamente) |
| `Status` | TEXT | Status atual (Pendente/EmAndamento/Concluida) |

---

## 📚 Aprendizados

Durante o desenvolvimento deste projeto, foram aplicados os seguintes conceitos:

✅ Desenvolvimento de APIs RESTful com **Minimal APIs**  
✅ Persistência de dados com **Entity Framework Core**  
✅ Utilização de **DTOs** para transferência de dados  
✅ Validações de dados com **Data Annotations**  
✅ Documentação automática com **Swagger/OpenAPI**  
✅ Boas práticas de versionamento com **Git/GitHub**  
✅ Organização de código em camadas (Models, DTOs, Data)  
✅ Tratamento de erros e respostas HTTP adequadas  

---

## 🤝 Contribuindo

Contribuições são bem-vindas! Sinta-se à vontade para:

1. Fazer um fork do projeto
2. Criar uma branch para sua feature (`git checkout -b feature/MinhaFeature`)
3. Commit suas mudanças (`git commit -m 'Adiciona nova feature'`)
4. Push para a branch (`git push origin feature/MinhaFeature`)
5. Abrir um Pull Request

---

## 👨‍💻 Autor

**Pedro Araújo**

[![GitHub](https://img.shields.io/badge/GitHub-100000?style=for-the-badge&logo=github&logoColor=white)](https://github.com/Pedro-arauj0)
[![LinkedIn](https://img.shields.io/badge/LinkedIn-0077B5?style=for-the-badge&logo=linkedin&logoColor=white)](https://www.linkedin.com/in/pedro-arthur-araujo/)

---

## 📄 Licença

Este projeto foi desenvolvido para fins educacionais como parte do bootcamp da **Digital Innovation One (DIO)**.

---

## 🙏 Agradecimentos

- [Digital Innovation One](https://www.dio.me/) - Pela oportunidade de aprendizado
- Comunidade .NET - Pelo suporte e documentação

---

⭐ **Se este projeto te ajudou, deixe uma estrela!** ⭐
