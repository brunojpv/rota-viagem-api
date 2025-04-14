# ✈️ Rota Viagem API

API REST em .NET 8 para cadastro de rotas aéreas e cálculo da **melhor rota entre dois pontos**, independentemente do número de conexões.

---

## 🚀 Tecnologias Utilizadas

- ASP.NET Core 8 (Minimal API)
- Entity Framework Core (InMemory)
- Swagger (Swashbuckle)
- xUnit (Testes automatizados)

---

## 🧠 Funcionalidade Principal

> Encontrar a **rota mais barata** entre dois aeroportos, mesmo que envolva múltiplas conexões.

### Exemplo:

Consulta: `GRU → CDG`  
Rotas possíveis:

1. `GRU → BRC → SCL → ORL → CDG = $40` ✅ (Melhor rota)
2. `GRU → ORL → CDG = $61`
3. `GRU → CDG = $75`
4. `GRU → SCL → ORL → CDG = $45`

---

## 📦 Endpoints Disponíveis

| Método | Endpoint                     | Descrição                         |
|--------|------------------------------|-----------------------------------|
| GET    | `/api/rotas`                 | Listar todas as rotas             |
| POST   | `/api/rotas`                 | Criar nova rota                   |
| PUT    | `/api/rotas/{id}`            | Atualizar rota existente          |
| DELETE | `/api/rotas/{id}`            | Remover uma rota                  |
| GET    | `/api/rotas/melhor?origem=XXX&destino=YYY` | Buscar a melhor rota entre dois pontos |

---

## ▶️ Como Executar Localmente

```bash
git clone https://github.com/seu-usuario/rota-viagem-api.git
cd rota-viagem-api
dotnet run --project RotaViagem
```
