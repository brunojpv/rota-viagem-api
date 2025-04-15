# ✈️ Rota Viagem API (.NET 8)

API REST com arquitetura moderna em .NET 8 utilizando **Minimal APIs**, **Swagger**, **TypedResults** e **AutoMapper**, focada em encontrar a **rota de viagem mais barata** entre dois aeroportos, mesmo com conexões.

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
- **AutoMapper** para conversão entre modelos e DTOs
- **DTOs** para entrada e saída mais seguras (`RotaCreateRequest`, `RotaResponse`)
- Swagger (Swashbuckle)
- EF Core InMemory
- xUnit para testes unitários

---

## 📦 Endpoints disponíveis

| Método | Endpoint                        | Descrição                                       |
|--------|----------------------------------|-------------------------------------------------|
| GET    | `/api/rotas`                    | Lista todas as rotas cadastradas (com DTOs)     |
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

Acesse no navegador:

🔗 `https://localhost:7235/swagger`

---

## 🧪 Executar os testes

Este projeto inclui testes automatizados com `xUnit`, cobrindo:

- Cálculo da melhor rota com múltiplas conexões
- Rotas diretas
- Casos sem rota possível
- Validação de entrada (nulos e strings vazias)

### Executar:
```bash
dotnet test
```

---

## 📄 Documentação via Swagger

- Swagger ativado na rota `/swagger`
- Exibe `summary` de métodos, parâmetros e schemas
- Atualizada automaticamente com base nos DTOs

Acesse em:
```bash
https://localhost:7235/swagger
```

---

## 🗂️ Estrutura do projeto

```bash
RotaViagem/
│
├── Models/               → Modelo de domínio (Rota)
├── DTOs/                 → Objetos de entrada e saída (RotaCreateRequest, RotaResponse)
├── Mappings/             → AutoMapper Profile (RotaProfile)
├── Data/                 → DbContext + Seed inicial
├── Services/             → Lógica da melhor rota
├── Controllers/          → Minimal API com IMapper
├── Program.cs            → Configuração de Swagger, DI e AutoMapper
└── RotaViagem.Tests/     → Testes de unidade com xUnit
```

---

## 👤 Autor
Bruno Vieira  
💼 Founder @ [Zenotech Solutions](https://www.instagram.com/zenotech.solutions)  
🌐 [https://github.com/brunojpv/](https://www.linkedin.com/in/brunojpv/)  
