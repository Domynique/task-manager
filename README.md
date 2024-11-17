# 🎓**Avaliação**

### **Desafio: Desenvolver uma API de Gerenciamento de Tarefas em C#**

O objetivo é desenvolver uma API em C# que implemente o CRUD para gerenciamento de tarefas e, no final, subir o código no GitHub para compartilhamento.

### **Nome do projeto**
- **TaskManager**

## **1. Tecnologias Utilizadas**

- **Linguagem de Programação:** C#
- **Frameworks:**
  - ASP.NET Core Web API
  - Entity Framework Core
- **Banco de Dados:** SQL Server
- **Documentação da API:** Swagger

## **2. Estrutura do Projeto**

A estrutura do projeto é organizada da seguinte forma:

```
  src/
    ├── Task.WPF/         - Interface em WPF 
    ├── Blog.Api/         - API RESTful
    ├── Blog.Business/    - Interfaces, Serviços e Configuração 
    ├── Blog.Data/        - Modelos de Dados e Configuração do EF Core
  README.md               - Arquivo de Documentação do Projeto
  .gitignore              - Arquivo de Ignoração do Git
```

## **3. Como Executar o Projeto**

### **Pré-requisitos**

- .NET SDK 8.0 ou superior
- SQL Server
- Visual Studio 2022 ou superior (ou qualquer IDE de sua preferência)
- Git

### **Passos para Execução**

1. **Clone o Repositório:**
   
   ```bash
   git clone https://github.com/Domynique/task-manager.git
   cd task-manager
   ```

2. **Executar o projeto:**
   
   ```bash
   taskmanager.sln
   ```

3. **Aplicar Migrations:**

- update-database no package-console (Projeto TaskManager.Data)   

4. **Selecionar projeto que deseja avaliar (WPF ou API):**

- Clicar com o botão direito no Projeto que deseja avaliar e selecionar "Definir como projeto de inicialização"
- Iniciar aplicação

<br />
## **4. Documentação da API**

A documentação da API está disponível através do Swagger. Após iniciar a API, acesse a documentação em:

http://localhost:5001/swagger





