# SaleService API 🛍️

[![Status do Deployment de Dev](https://img.shields.io/github/deployments/leonardolimaArt/SaleService/development?label=development&style=for-the-badge)](https://github.com/leonardolimaArt/SaleService/deployments)
[![Versão](https://img.shields.io/badge/version-1.0.0-blue?style=for-the-badge)](./)

API de microsserviços para um sistema de vendas, construída com .NET e conteinerizada com Docker. O projeto demonstra uma arquitetura desacoplada e escalável para aplicações de e-commerce.

### **Status do Projeto:** Em desenvolvimento
### **Acesso:** http://saleservicegatewayapi-development.up.railway.app
---

## Sobre o Projeto

O **SaleService** é uma solução backend para uma aplicação de vendas. Ele é dividido em serviços independentes que se comunicam de forma assíncrona, garantindo resiliência e facilidade de manutenção.

![Arquitetura do SaleService](doc/arch_diagram.png)

## Arquitetura

A arquitetura do sistema é dividida em camadas lógicas para organizar as responsabilidades:

-   **Gateway:** Ponto de entrada único para todas as requisições dos clientes. Roteia as chamadas para os microsserviços apropriados.
    -   `SaleService.Gateway.API`: Implementado com YARP.

-   **Camada de Microsserviços (Microservices Layer):** Contém a lógica de negócio principal.
    -   `SaleService.Catalog.API`: Gerencia o catálogo de produtos (consultas, criações, atualizações), possui 1 milhão de produtos da Amazon.
    -   `SaleService.Basket.API`: Gerencia o carrinho de compras dos usuários (adicionar, remover, consultar itens).

-   **Camada de Banco de Dados (Database Layer):** Responsável pela persistência dos dados.
    -   **MongoDB**: Usado pelo serviço de Catálogo para armazenar os dados dos produtos de forma flexível.
    -   **Redis**: Usado pelo serviço de Carrinho para armazenar dados de sessão e cache de forma rápida.

## Tecnologias Utilizadas

-   **Backend:** .NET 8 / C#
-   **Framework API:** ASP.NET Core
-   **Conteinerização:** Docker & Docker Compose
-   **Banco de Dados:** MongoDB, Redis
-   **Gateway:** YARP

## Uso da API

A seguir, os endpoints disponíveis através do Gateway.

**Serviço de Catálogo (Gateway API)**

- Catalog: http://saleservicegatewayapi-development.up.railway.app/catalog/
- Basket: http://saleservicegatewayapi-development.up.railway.app/basket/

**Serviço de Catálogo (Catalog API)**
* [GET /api/v1/catalog/items](http://saleservicegatewayapi-development.up.railway.app/catalog/api/v1/Product): Retorna a lista de produtos.
* [GET /api/v1/catalog/items/{id}](http://saleservicegatewayapi-development.up.railway.app/catalog/api/v1/Product/686e956e68628a0d2af57047): Retorna um produto específico.

**Serviço de Carrinho (Basket API)**
* [GET /api/v1/basket/{username}](https://saleservicebasketapi-production.up.railway.app/api/v1/Basket/Leonardo) : Retorna o carrinho de um usuário.
* [POST /api/v1/basket](): Atualiza o carrinho.
* [DELETE /api/v1/basket/{username}](): Limpa o carrinho.
