Projeto

## Arquitetura:

- Full architecture with responsibility separation concerns, SOLID and Clean Code
- Domain Driven Design (Layers and Domain Model Pattern)
- Domain Events
- Domain Notification
- Domain Validations
- CQRS (Imediate Consistency)
- Event Sourcing
- Unit of Work
- Repository

### Solução:
 feita em API, com DDD, CQRS, banco de dados usado foi o postgree(free). Usei como referencia o projeto Equinox do Eduardo Pires.  
1 - Na camada de Service coloquei o Controllers
2 - na camada Application coloquei os serviços e as interface das mesmas. o AutoMapper e ViewModels.
3 - na camada Domain coloquei os commands do CQRS, os cmammand Hadlers. os Dtos, os nodelos de dados e as interface para o Repository.
4 - na camada de Infra coloquei a Data com context, mapeamento, migrations, repository. CrossCutting onde esta a IOC. Email para enviar e-mails.

Estratégia de teste para esta solução (o que testar)
R: não fiz um projeto de testes. tenho conhecimento básico. 

Quais ferramentas e tecnologias você usou (bibliotecas, estrutura, 
ferramentas, tipos de armazenamento, recursos da plataforma em nuvem)
R:
- ASP.NET Core 3.1 (with .NET Core 3.1)
 - ASP.NET MVC Core 
 - ASP.NET WebApi Core with JWT Bearer Authentication
 - ASP.NET Identity Core
- Entity Framework Core 3.1
- .NET Core Native DI
- AutoMapper
- FluentValidator
- MediatR
- Swagger UI with JWT support

O que você acha que pode ser melhorado e como
R: a modelagem e o mapeamento, poderiam ser melhorados. 

Qualquer coisa que você achar benéfico colocar aqui
R: eu fiz de forma rápida não sei se esta da melhor forma, ou muito distante do que foi solicitado.


