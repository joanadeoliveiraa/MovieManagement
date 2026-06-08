# MovieManagement

Projeto desenvolvido em C# no âmbito da unidade curricular de Design Patterns.

## Objetivo

Desenvolver uma aplicação de gestão de filmes utilizando:

- Arquitetura em Camadas
- Interfaces
- Regras de Negócio
- Persistência de Dados
- Git e GitHub

---

## Arquitetura

O projeto está organizado nas seguintes camadas:

```text
MovieManagement
│
├── MovieManagement.UI
├── MovieManagement.Business
├── MovieManagement.Data
└── MovieManagement.Domain
```

### Responsabilidades

| Camada | Responsabilidade |
|---------|------------------|
| UI | Interação com o utilizador |
| Business | Regras de negócio |
| Data | Persistência de dados |
| Domain | Entidades e interfaces |

---

## Funcionalidades Implementadas

### Parte 1 – Gestão de Filmes

- Adicionar filme
- Listar filmes
- Procurar filme por título
- Remover filme
- Pesquisa parcial por título

### Regras de Negócio

- Título obrigatório
- Não permitir títulos duplicados
- Classificação válida entre 0 e 5

---

## Utilização de Enum

Foi utilizado um Enum para a classificação dos filmes.

Vantagens:

- Evita números mágicos no código
- Melhora a legibilidade
- Limita os valores possíveis
- Reduz erros de utilização

Exemplo:

```csharp
public enum ClassificacaoFilme
{
    MuitoMau = 0,
    Mau = 1,
    Razoavel = 2,
    Bom = 3,
    MuitoBom = 4,
    Excelente = 5
}
```

---

## Tecnologias Utilizadas

- C#
- .NET
- SQLite
- Visual Studio
- Git
- GitHub

---

### Parte 2 – Gestão de Categorias e Realizadores

### Categorias

Funcionalidades implementadas:

* Adicionar categoria
* Listar categorias
* Procurar categoria
* Remover categoria

Regras de negócio:

* Nome da categoria obrigatório
* Não permitir categorias duplicadas
* Pesquisa parcial por nome
* Tratamento de erros e validações

### Realizadores

Funcionalidades implementadas:

* Adicionar realizador
* Listar realizadores
* Procurar realizador
* Remover realizador

Regras de negócio:

* Nome obrigatório
* País obrigatório
* Não permitir realizadores duplicados
* Pesquisa parcial por nome
* Tratamento de erros e validações

### Arquitetura Implementada

Para ambas as entidades foram implementadas:

* Entidade (Domain)
* Interface (Domain.Interfaces)
* Repository (Data.Repositories)
* Service (Business.Services)
* Integração com a interface de utilizador (UI)

Foi mantida a arquitetura em camadas utilizada em todo o projeto:

* UI (Interface com o utilizador)
* Business (Regras de negócio)
* Data (Persistência de dados)
* Domain (Entidades e contratos)
  
---

## Parte 3 – Relacionamentos e Persistência SQLite

### Relacionamentos Implementados

Foram implementados relacionamentos entre as entidades do sistema:

* Cada Filme pertence a uma Categoria
* Cada Filme possui um Realizador

Durante a criação de um filme é possível selecionar a categoria e o realizador a partir dos registos existentes.

### Persistência SQLite

A aplicação utiliza SQLite como mecanismo de persistência de dados, permitindo manter categorias, realizadores e filmes registados entre execuções da aplicação.

Funcionalidades implementadas:

* Criação automática da base de dados `MovieManagement.db`
* Criação automática das tabelas:

  * Categorias
  * Realizadores
  * Filmes
* Implementação de repositories SQLite para todas as entidades
* Persistência permanente dos dados após encerramento da aplicação


### Funcionalidades Disponíveis

#### Filmes

* Adicionar filme
* Listar filmes
* Procurar filme
* Remover filme

#### Categorias

* Adicionar categoria
* Listar categorias
* Procurar categoria
* Remover categoria

#### Realizadores

* Adicionar realizador
* Listar realizadores
* Procurar realizador
* Remover realizador


---

## Estado Atual do Projeto

### Concluído

- Parte 1 – Gestão de Filmes
- Parte 2 – Gestão de Categorias e Realizadores
- Parte 3 – Relacionamentos entre entidades e persistência SQLite

O projeto encontra-se funcional e cumpre os requisitos das três partes do enunciado.
  

## Autor

Joana Oliveira

Projeto académico desenvolvido para aprendizagem de Arquitetura em Camadas, Design Patterns e Boas Práticas de Programação.
