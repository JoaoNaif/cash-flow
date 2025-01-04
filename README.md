# Sobre o projeto

O projeto é uma **API REST** de controle de despesas, desenvolvida com **C#** e **.NET 8** Core em **ASP.NET**, seguindo princípios de **DDD e SOLID**. Ele está totalmente documentado com **Swagger**, utiliza **MySQL** como banco de dados, é um sistema de controle de despesas e **oferece a funcionalidade de gerar relatórios em formatos PDF e Excel.**

### Features

- **Domain-Driven Design (DDD)**
Organização do projeto baseada em domínios, separando responsabilidades em camadas como domínio, aplicação, infraestrutura e interface.
Benefícios: Facilita a manutenção, escalabilidade e entendimento do sistema, permitindo que a lógica de negócios seja o foco principal.

- **API REST com Swagger**
A API segue o padrão REST e é totalmente documentada com Swagger.
Benefícios: Proporciona padronização e clareza na comunicação com consumidores da API, além de facilitar o teste e o uso por desenvolvedores.

- **Geração de Relatórios em PDF e Excel**
Funcionalidade para exportar dados em formatos amplamente utilizados, como PDF e Excel.
Benefícios: Melhora a usabilidade para usuários finais, fornecendo formas práticas e acessíveis de visualizar e compartilhar informações.

- **Teste de Unidade**
Implementação de testes automatizados para validar a funcionalidade de unidades específicas do código.
Benefícios: Aumenta a confiabilidade do sistema, reduzindo bugs e garantindo que alterações futuras não quebrem funcionalidades existentes.

### Construído com

![badge-net]
![badge-swagger]
![badge-mysql]
![badge-linux]

## Getting Started

Para obter um cópia local funcionando, siga estes passos simples.

### Requisitos

* Visual Studio versão 2022+, Visual Studio Code ou Rider
* Windows 10+ ou Linux/MacOs com [.NET SDK][dot-net-sdk] instaldo
* MySql Server

### Instalação

1. Clone o repositório:
    ```sh
    git clone https://github.com/JoaoNaif/cash-flow
    ```
2. Preencha as informações no arquivo `appsettings.Development.json`
3. Execute a API e aproveite o seu teste





<!-- Links -->
[dot-net-sdk]: https://dotnet.microsoft.com/en-us/download/dotnet/8.0
[badge-net]: https://img.shields.io/badge/.NET-512BD4?logo=dotnet&logoColor=fff&style=for-the-badge
[badge-swagger]: https://img.shields.io/badge/Swagger-85EA2D?logo=swagger&logoColor=000&style=for-the-badge
[badge-mysql]: https://img.shields.io/badge/MySQL-4479A1?logo=mysql&logoColor=fff&style=for-the-badge
[badge-linux]: https://img.shields.io/badge/Linux-FCC624?logo=linux&logoColor=000&style=for-the-badge