# Sistema Escolar - ASP.NET Core MVC (.NET 9)


## Requisitos

- .NET 9 SDK instalado

## Como executar

1. Abra um terminal na pasta do projeto
2. Restaure pacotes:
   ```bash
   dotnet restore
   ```
3. Rode o projeto:
   ```bash
   dotnet run
   ```
4. Abra o navegador em https://localhost:5001 ou o endereço mostrado no terminal.

O projeto usa SQLite (arquivo `SistemaEscolar.db`) e o banco será criado automaticamente na primeira execução.


## Novos módulos gerados
- Cursos (CRUD)
- Professores (CRUD)
- Turmas (CRUD) com seleção de Curso/Professor
- Matrículas (CRUD parcial) com seleção de Aluno/Turma

Acesse /Cursos /Professores /Turmas /Matriculas no navegador.


## Seed e UI
O projeto agora inclui:
- Bootstrap 5 na interface (layout atualizado)
- Seed automático de dados na primeira execução (Program.cs -> SeedDatabase)
- seed_data.sql com comandos CREATE + INSERT (SQLite)

Para recriar o banco manualmente, rode `sqlite3 SistemaEscolar.db < seed_data.sql` ou use o seed automático (db.Database.EnsureCreated() + SeedDatabase).
