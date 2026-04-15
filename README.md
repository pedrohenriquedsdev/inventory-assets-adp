# 📦 Gestão de Equipamentos e Chamados

> Sistema de console desenvolvido em C# para gerenciamento de fabricantes, equipamentos e chamados de manutenção — projeto introdutório de Programação Orientada a Objetos.

<p align="left">
  <img src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white" />
  <img src="https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" />
  <img src="https://img.shields.io/badge/Console_App-black?style=for-the-badge&logo=windows-terminal&logoColor=white" />
  <img src="https://img.shields.io/badge/Status-Concluído-brightgreen?style=for-the-badge" />
</p>

---

## 🎯 Sobre o Projeto

O **Gestão de Equipamentos e Chamados** é uma aplicação de console criada para fins educacionais, desenvolvida como projeto prático da disciplina de **Programação Orientada a Objetos**.

O sistema simula um ambiente real de controle de ativos de TI — permitindo o cadastro de fabricantes, registro de equipamentos e abertura de chamados de manutenção — tudo isso sem banco de dados, utilizando apenas **armazenamento em memória (arrays)** e os conceitos fundamentais do C#.

---

## ✨ Funcionalidades

### 🏭 Módulo de Fabricantes

| Funcionalidade | Descrição |
|---|---|
| Cadastrar fabricante | Registra um novo fabricante no sistema |
| Listar fabricantes | Exibe todos os fabricantes cadastrados |
| Editar fabricante | Atualiza as informações de um fabricante |
| Excluir fabricante | Remove um fabricante do sistema |

Atributos de um fabricante:
- 🔑 `Id` — gerado automaticamente
- 🏷️ `Nome` — nome da empresa fabricante
- 🌍 `PaisDeOrigem` — país de origem da empresa

---

### 🖥️ Módulo de Equipamentos

| Funcionalidade | Descrição |
|---|---|
| Cadastrar equipamento | Registra um novo equipamento vinculado a um fabricante |
| Listar equipamentos | Exibe todos os equipamentos cadastrados |
| Editar equipamento | Atualiza os dados de um equipamento existente |
| Excluir equipamento | Remove um equipamento do sistema |

Atributos de um equipamento:
- 🔑 `Id` — gerado automaticamente
- 🏷️ `Nome` — nome do equipamento
- 🏭 `Fabricante` — fabricante relacionado
- 💰 `PrecoAquisicao` — valor de compra
- 📅 `DataFabricacao` — data de fabricação

---

### 🔧 Módulo de Chamados

| Funcionalidade | Descrição |
|---|---|
| Abrir chamado | Registra um chamado vinculado a um equipamento |
| Listar chamados | Exibe todos os chamados e seus detalhes |
| Editar chamado | Atualiza informações de um chamado existente |
| Excluir chamado | Remove o chamado do sistema |

Atributos de um chamado:
- 🔑 `Id` — gerado automaticamente
- 📝 `Titulo` — título do chamado
- 📋 `Descricao` — detalhamento do problema
- 🖥️ `Equipamento` — equipamento relacionado ao chamado
- 📅 `DataAbertura` — data de criação do chamado
- ⏳ `DiasEmAberto` — calculado automaticamente a partir da data atual

---

## 🛠️ Tecnologias Utilizadas

- [C#](https://learn.microsoft.com/pt-br/dotnet/csharp/) — Linguagem principal
- [.NET](https://dotnet.microsoft.com/) — Plataforma de desenvolvimento
- **Console Application** — Interface via terminal, sem dependências externas
- **Armazenamento em memória** — Arrays simples, sem banco de dados

---

## 📁 Estrutura do Projeto

```
GestaoDeEquipamentos/
│
├── GestaoDeEquipamentos.slnx              # Arquivo de solução
│
└── GestaoDeEquipamentos.ConsoleApp/       # Projeto principal
    │
    ├── Program.cs                         # Ponto de entrada da aplicação
    │
    ├── Dominio/                           # Entidades do sistema
    │   ├── Fabricante.cs                  # Classe Fabricante
    │   ├── Equipamento.cs                 # Classe Equipamento
    │   └── Chamado.cs                     # Classe Chamado
    │
    ├── Apresentacao/                      # Interação com o usuário
    │   ├── TelaFabricante.cs              # Menu e inputs de fabricantes
    │   ├── TelaEquipamento.cs             # Menu e inputs de equipamentos
    │   └── TelaChamado.cs                 # Menu e inputs de chamados
    │
    └── Infraestrutura/                    # Armazenamento dos dados
        ├── RepositorioFabricante.cs       # CRUD de fabricantes em memória
        ├── RepositorioEquipamento.cs      # CRUD de equipamentos em memória
        └── RepositorioChamado.cs          # CRUD de chamados em memória
```

---

## 🚀 Como Executar o Projeto

### Pré-requisitos

- [.NET SDK](https://dotnet.microsoft.com/download) instalado (versão 8.0 ou superior)
- Terminal (CMD, PowerShell, bash ou qualquer outro)

### Passos

```bash
# Clone o repositório
git clone https://github.com/pedrohenriquedsdev/inventory-assets-adp.git

# Acesse a pasta do projeto
cd inventory-assets-adp/GestaoDeEquipamentos.ConsoleApp

# Execute a aplicação
dotnet run
```

---

## 🧠 Conceitos de POO Aplicados

Este projeto foi desenvolvido para colocar em prática os pilares da Programação Orientada a Objetos de forma simples e direta.

### 🔹 Classes e Objetos
Cada entidade do sistema (`Fabricante`, `Equipamento`, `Chamado`) é representada por uma **classe**. Cada registro criado pelo usuário é um **objeto** dessa classe — ou seja, uma instância com seus próprios dados e comportamentos.

### 🔹 Encapsulamento
Os dados internos de cada classe são expostos através de **propriedades**, garantindo que o acesso e a modificação aconteçam de forma controlada, sem expor diretamente os campos internos.

### 🔹 Associação entre Objetos
Um `Equipamento` referencia um `Fabricante`, e um `Chamado` referencia um `Equipamento`. Essa ligação entre objetos reflete relacionamentos do mundo real dentro do código — um conceito fundamental da modelagem orientada a objetos.

### 🔹 Abstração
O usuário interage apenas com menus simples. A complexidade de como os dados são armazenados e manipulados fica escondida nas camadas de infraestrutura — o usuário não precisa saber como isso funciona por baixo.

### 🔹 Separação de Responsabilidades
Cada camada do projeto tem uma função bem definida:
- **Domínio** → define as entidades e suas regras
- **Apresentação** → cuida da interface com o usuário (inputs e menus)
- **Infraestrutura** → armazena e recupera os dados em memória

---

## 🔄 Fluxo do Sistema

O `Program.cs` é o coração da aplicação. Ele inicializa os repositórios e as telas, conectando todas as camadas:

```
Program.cs
  ├── Instancia os repositórios (Fabricante, Equipamento, Chamado)
  ├── Instancia as telas, injetando os repositórios necessários
  └── Exibe o menu principal em loop até o usuário escolher sair
```

O fluxo de uma operação segue este caminho:

```
Usuário
  → Tela (Apresentação)          — coleta os dados e exibe resultados
  → Repositório (Infraestrutura) — executa a operação no array
  → Objeto (Domínio)             — representa o dado manipulado
```

---

## 🖱️ Exemplo de Uso

```
╔══════════════════════════════════════╗
║   GESTÃO DE EQUIPAMENTOS E CHAMADOS  ║
╠══════════════════════════════════════╣
║  [1] Gerenciar Fabricantes           ║
║  [2] Gerenciar Equipamentos          ║
║  [3] Gerenciar Chamados              ║
║  [0] Sair                            ║
╚══════════════════════════════════════╝
> 1

--- FABRICANTES ---
[1] Cadastrar  [2] Listar  [3] Editar  [4] Excluir  [0] Voltar
> 1

Nome do fabricante: Dell Technologies
País de origem: Estados Unidos

✅ Fabricante cadastrado com sucesso! ID: 1

> 0

> 2

--- EQUIPAMENTOS ---
[1] Cadastrar  [2] Listar  [3] Editar  [4] Excluir  [0] Voltar
> 1

Nome do equipamento: Notebook Dell Latitude
Fabricante (ID): 1
Preço de aquisição: 4200,00
Data de fabricação (dd/mm/aaaa): 15/06/2023

✅ Equipamento cadastrado com sucesso! ID: 1

> 0

> 3

--- CHAMADOS ---
[1] Abrir  [2] Listar  [3] Editar  [4] Excluir  [0] Voltar
> 1

Título: Tela com defeito
Descrição: Linhas horizontais aparecendo na tela ao ligar o notebook
Equipamento (ID): 1

✅ Chamado aberto com sucesso! ID: 1  |  Dias em aberto: 0
```

---

## 👨‍💻 Autor

Desenvolvido por **Pedro Henrique** como projeto de estudo para praticar os fundamentos de **C#** e **Programação Orientada a Objetos**.

[![GitHub](https://img.shields.io/badge/GitHub-pedrohenriquedsdev-181717?style=flat&logo=github)](https://github.com/pedrohenriquedsdev)

---

## 📄 Licença

Este projeto está sob a licença [MIT](LICENSE.txt). Sinta-se à vontade para usar, estudar e modificar.
