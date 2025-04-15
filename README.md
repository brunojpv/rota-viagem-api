# ✈️ Rota Viagem API (.NET 8)

API REST com arquitetura moderna em .NET 8 utilizando **Minimal APIs**, **Swagger** e **TypedResults**, focada em encontrar a **rota de viagem mais barata** entre dois aeroportos, independente de conexões.

---

## 🧠 Funcionalidade principal

Dado um conjunto de rotas (com origem, destino e valor), a API é capaz de encontrar o **caminho mais barato** entre dois pontos.

### 🧪 Exemplo:

Consulta: `GRU → CDG`  
Rotas possíveis:

1. `GRU → BRC → SCL → ORL → CDG = $40` ✅
2. `GRU → ORL → CDG = $61`
3. `GRU → CDG = $75`

🟢 Resultado retornado:  
**`GRU - BRC - SCL - ORL - CDG ao custo de $40`**

---

## 🔧 Tecnologias utilizadas

- [.NET 8](https://dotnet.microsoft.com/)
- Minimal API com `TypedResults`
- Swagger (Swashbuckle)
- EF Core InMemory
- xUnit para testes unitários

---

## 📦 Endpoints disponíveis

| Método | Endpoint                        | Descrição                                       |
|--------|---------------------------------|-------------------------------------------------|
| GET    | `/api/rotas`                    | Lista todas as rotas cadastradas                |
| POST   | `/api/rotas`                    | Cadastra uma nova rota                          |
| PUT    | `/api/rotas/{id}`               | Atualiza uma rota existente                     |
| DELETE | `/api/rotas/{id}`               | Remove uma rota                                 |
| GET    | `/api/rotas/melhor?origem=X&destino=Y` | Retorna a **melhor rota** entre dois pontos |

---

## ▶️ Como executar o projeto

```bash
git clone https://github.com/brunojpv/rota-viagem-api.git
cd rota-viagem-api
dotnet run --project RotaViagem
```

Abra o navegador em:

🔗 `https://localhost:7235/swagger`

---

## 🧪 Executar os testes

```bash
dotnet test
```

Testes de unidade com `xUnit`, cobrindo:

- Melhor rota entre cidades
- Casos sem rota possível
- Casos diretos e com múltiplas conexões

---

## 📄 Documentação via Swagger

- Swagger habilitado em `/swagger`
- Comentários dos métodos e propriedades exibidos (via XML Docs)
- Documentação limpa e intuitiva

---

## 🗂️ Estrutura do projeto

```bash
RotaViagem/
|
├── Models/           → Modelo da rota (Origem, Destino, Valor)
├── Data/             → DbContext e Seeder
├── Services/         → Lógica de cálculo da melhor rota
├── Controllers/      → Minimal API separada em classe externa
├── Program.cs        → Configuração do app e Swagger
└── RotaViagem.Tests/ → Testes automatizados com xUnit
```

---

## 👤 Autor
Bruno Vieira  
💼 Founder @ Zenotech Solutions  
🌐 [https://github.com/brunojpv/](https://www.linkedin.com/in/brunojpv/)  
