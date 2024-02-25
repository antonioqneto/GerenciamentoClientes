# Gerenciamento de Clientes

Sistema de gerenciamento de clientes, implementando listagem e formulários de cadastro, visualização, edição e exclusäo (CRUD), organizado em 3 camadas (MVC).

## Stack

* Asn.net Core
* BLazor WebAssembly / Bootstrap
* SQLite / Entity Framewwork Core

## Funcionalidades

* Páginas implementadas - Listagem e Formulário
* Rotas Funcionais 
* Validação de Entrada
* Banco de dados implementado, com migration e dados iniciais

## Implementação

Após compilar os projetos, inserir no Package Manager Console o comando
```
add-migration Init
```
e, em seguida,
```
update-database
```
Assim, nosso banco (SQLite) já estará inicializado e criado em  ```GerenciamentoClientesApi/gerenciamentoClientes.db```

Para rodar a aplicação, mude a execuçao https para IIS Express em ```GerenciamentoClientesApi``` e ```GerenciamentoClientesBlazor```.
Defina esses projetos para [inicialização múltipla](https://learn.microsoft.com/pt-br/visualstudio/ide/how-to-set-multiple-startup-projects?view=vs-2022).

---
## TODOs 

* Montar tutorial de implementação e Deploy
* Referëncias
  -  [API](https://learn.microsoft.com/en-us/aspnet/core/host-and-deploy/?view=aspnetcore-8.0)
  -  [IIS](https://stackify.com/how-to-deploy-asp-net-core-to-iis/)
  -  [Nginx](https://www.treinaweb.com.br/blog/publicando-uma-aplicacao-asp-net-core-no-linux-com-o-nginx)
  -  [GitHub Actions e Azure](https://balta.io/blog/aspnet-deploy-github-actions-azure)
  -  [ASP.NET Core Blazor WebAssembly](https://learn.microsoft.com/en-us/aspnet/core/blazor/host-and-deploy/webassembly?view=aspnetcore-8.0)
  -  [GCP](https://cloud.google.com/dotnet/docs/getting-started/getting-started-on-compute-engine-net-netframework)
  -  [Kubernetes](https://macoratti.net/22/05/kubern_aspndeplo1.html)
  -  [IIS](https://www.guru99.com/deploying-website-iis.html)

* Estilização front
* Adição de campos não obrigatórios em Cliente
* Validação para evitar dados duplicados e cadastros múltiplos
* implementação botões de contato
    - whatspp
    - email
* Implantar Modal para Visualização e Exclusäo de Cliente
  * campos travados
  * exibição do modelo completo
* Tratar responsividade
