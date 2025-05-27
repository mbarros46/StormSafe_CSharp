# 🌊 StormSafe API (.NET)

API RESTful desenvolvida para a disciplina **Advanced Business Development with .NET**, com o objetivo de auxiliar a população durante enchentes, utilizando sensores, rotas de evacuação e alertas.

---

## ✅ Requisitos Atendidos

- [x] API REST com boas práticas e arquitetura organizada
- [x] Persistência em banco de dados relacional (PostgreSQL)
- [x] Relacionamento 1:N entre entidades (`Rio` → `Sensor`)
- [x] Documentação com Swagger
- [x] Aplicação de Razor Pages com TagHelpers (painel admin)
- [x] Uso correto de Migrations com EF Core

---

## 🗃 Diagrama de Entidades

```
Rio (1) -------- (N) Sensor
 |
 +--- Alerta
 |
 +--- RotaEvacuacao
```

---

## ▶️ Instruções para Rodar

1. Crie o banco no PostgreSQL:

```sql
CREATE DATABASE "StormSafeDB";
```

2. Atualize o banco com EF Core:

```bash
dotnet ef database update
```

3. Execute a aplicação:

```bash
dotnet run
```

---

## 🧪 Exemplos de Testes com Swagger

- `GET /api/rio` – listar rios
- `POST /api/sensor` – cadastrar sensor em rio
- `GET /api/alerta` – ver alertas de enchente
- `POST /api/rota` – cadastrar rota de evacuação

Acesse via: `https://localhost:5001/swagger`

---

## 📹 Vídeos Obrigatórios

- 🎬 [Demonstração da Solução Completa – máx. 8 min](https://youtube.com)
- 🎤 [Pitch da Solução – máx. 3 min](https://youtube.com)

---

## 👨‍💻 Integrantes

- Pedro Valentim Merise — RM556826
- Miguel Barros Ramos — RM556652
