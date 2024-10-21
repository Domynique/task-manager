# **Teste Recrutamento**

### **Desafio: Desenvolver uma API de Gerenciamento de Tarefas em C#**

O objetivo é desenvolver uma API em C# que implemente o CRUD para gerenciamento de tarefas e, no final, subir o código no GitHub para compartilhamento.


### **Nome do projeto**
- **TaskManager**


## **Passo para configurar o projeto a partir do Git**

Clonar o Repositório:

- git clone https://github.com/Domynique/task-manager.git.


Navegar até a pasta do projeto:

- cd [repositorio]


Restaurar Pacotes Nuget

- dotnet restore


Confirmar String de Conexão:

- {"ConnectionStrings": {"DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=BancoDemo;Trusted_Connection=True;MultipleActiveResultSets=true"}}


Aplicar Migrations e Update do Banco de Dados

- dotnet ef database update


Aplicar Migrations e Update do Banco de Dados

- dotnet ef database update


Subir o projeto

- dotnet build


Executar a Aplicação:

- dotnet run --project TaskManager.API
- dotnet run --project TaskManager.WPF




