# KM One Connect

Projeto pessoal em desenvolvimento para explorar a construção de uma plataforma de aluguel de veículos entre motoristas de aplicativo.

> Status: em desenvolvimento. O repositório ainda não representa um produto final; ele documenta a evolução da modelagem de domínio, da arquitetura backend e das decisões técnicas do projeto.

## Ideia do produto

O KM One Connect parte de um problema comum para motoristas de aplicativo: nem todo motorista que quer trabalhar em plataformas como Uber e 99 possui um carro disponível.

Ao mesmo tempo, proprietários ou outros motoristas podem ter veículos parados ou disponíveis para locação. A proposta do projeto é aproximar esses dois lados por meio de uma plataforma onde veículos possam ser anunciados e alugados por períodos definidos.

## Objetivo do repositório

Este repositório existe principalmente para tornar o código e a evolução técnica do projeto visíveis.

A intenção é que outras pessoas possam:

- entender o problema que o projeto tenta resolver;
- acompanhar a modelagem inicial do domínio;
- ver a separação entre camadas;
- analisar decisões de arquitetura;
- acompanhar a evolução do backend ao longo do desenvolvimento.

## Stack atual

- .NET 10
- ASP.NET Core Web API
- xUnit
- Arquitetura em camadas

## Organização do código

```text
backend/
  src/
    KMOneConnect.Api/             # Entrada HTTP da aplicação
    KMOneConnect.Application/     # Casos de uso e regras de aplicação
    KMOneConnect.Domain/          # Entidades, value objects e regras de domínio
    KMOneConnect.Infrastructure/  # Persistência, integrações e serviços externos
    KMOneConnect.Lab/             # Área experimental
  tests/
    KMOneConnect.Domain.Tests/    # Testes automatizados do domínio
  docs/
    domain-model.md               # Anotações iniciais sobre o modelo de domínio
```

## Modelo de domínio

A camada `KMOneConnect.Domain` concentra a parte mais importante neste momento do projeto. Ela contém os conceitos centrais e as primeiras regras de negócio.

Conceitos já iniciados:

- `Driver`: representa um motorista ou proprietário na plataforma.
- `Vehicle`: representa um veículo cadastrado por um proprietário.
- `RentalOffer`: representa uma oferta de locação de veículo.
- `Money`: representa valores monetários.
- `DocumentNumber`: representa CPF ou CNPJ.
- `Plate`: representa uma placa veicular.
- `RentalPeriod`: representa o período de locação.

Estados iniciais de uma oferta:

- `Draft`
- `Active`
- `Paused`
- `Closed`

## Funcionalidades planejadas

- Cadastro e verificação de motoristas.
- Cadastro de veículos.
- Criação e publicação de ofertas de aluguel.
- Busca e listagem de ofertas disponíveis.
- Solicitação de aluguel por motoristas interessados.
- Aceite ou recusa de solicitações.
- Geração de contratos a partir de solicitações aceitas.
- Persistência dos dados.
- Autenticação e autorização.
- Observabilidade e preparação para ambientes reais.

## Princípios técnicos

Alguns princípios que guiam a construção do projeto:

- manter regras de negócio dentro do domínio;
- evitar dependências de infraestrutura na camada de domínio;
- separar responsabilidades entre API, aplicação, domínio e infraestrutura;
- usar testes automatizados para validar regras importantes;
- evoluir a arquitetura junto com as necessidades reais do projeto.

## O que ainda está em aberto

Como o projeto ainda está em fase inicial, alguns pontos importantes ainda serão definidos ou implementados:

- persistência de dados;
- casos de uso completos na camada de aplicação;
- endpoints reais da API;
- autenticação;
- autorização;
- tratamento padronizado de erros;
- contratos e solicitações de aluguel;
- documentação técnica mais detalhada.

## Observação

Este é um projeto pessoal e em desenvolvimento contínuo. O código deve ser lido como uma base em evolução, não como uma implementação finalizada.
