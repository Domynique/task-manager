# **Teste Recrutamento**

### **Desafio: Desenvolver uma API de Gerenciamento de Tarefas em C#**

O objetivo é desenvolver uma API em C# que implemente o CRUD para gerenciamento de tarefas e, no final, subir o código no GitHub para compartilhamento.


### **Nome do projeto**
- **TaskManager**


## **Passo para configurar o projeto a partir do Git**

Clonar o Repositório:

- git clone https://github.com/Domynique/task-manager.git


Navegar até a pasta do projeto:

- cd [..]\task-manager\askmanager\


Restaurar Pacotes Nuget

- dotnet restore


Execute a Solution

- [..]\task-manager\askmanager\TaskManager.sln


Confirmar String de Conexão:

- Abrir o projeto API e verificar o arquivo appsettings.json
- {"ConnectionStrings": {"DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=BancoDemo;Trusted_Connection=True;MultipleActiveResultSets=true"}}


Definir Projeto API como startup project:

- O projeto esta configurado para Multipla Inicialização (API e WPF) 
- Clicar com o direito no Projeto API e selecionar "Definir como projeto de inicialização"

Aplicar Migrations e Update do Banco de Dados

- Executa update-database no package-console (Gerenciador de pacotes)


Definir na Solução Multipla Inicialização

- Clicar com botão direito na Solution, opção propriedades, na opção selecionada projeto de inicialização marcar "vários projetos de inicializacao".


Iniciar Aplicação



