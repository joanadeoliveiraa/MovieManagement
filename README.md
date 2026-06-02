# MovieManagement_JoanaOliveira

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

├─ MovieManagement.UI
├─ MovieManagement.Business
├─ MovieManagement.Data
└─ MovieManagement.Domain
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
- Visual Studio
- Git
- GitHub

---

## Autor

Joana Oliveira

Projeto académico desenvolvido para aprendizagem de Arquitetura em Camadas, Design Patterns e Boas Práticas de Programação.
