using Microsoft.EntityFrameworkCore;
using SistemaEscolar.Data;
using SistemaEscolar.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure EF Core with SQLite
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Ensure database is created and seeded
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.EnsureCreated();
    SeedDatabase(db);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


static void SeedDatabase(ApplicationDbContext db)
{
    if (db.Cursos.Any()) return; // already seeded

    // Cursos
    var c1 = new Curso { Nome = "Ciência da Computação", DuracaoSemestres = 8 };
    var c2 = new Curso { Nome = "Engenharia Elétrica", DuracaoSemestres = 10 };
    var c3 = new Curso { Nome = "Administração", DuracaoSemestres = 8 };
    var c4 = new Curso { Nome = "Matemática", DuracaoSemestres = 6 };
    var c5 = new Curso { Nome = "Pedagogia", DuracaoSemestres = 8 };
    db.Cursos.AddRange(c1, c2, c3, c4, c5);
    db.SaveChanges();

    // Professores
    var p1 = new Professor { Nome = "Mariana Silva", Disciplina = "Programação" };
    var p2 = new Professor { Nome = "Carlos Souza", Disciplina = "Calculo" };
    var p3 = new Professor { Nome = "Fernanda Lima", Disciplina = "Administração" };
    var p4 = new Professor { Nome = "João Pereira", Disciplina = "Didática" };
    db.Professores.AddRange(p1, p2, p3, p4);
    db.SaveChanges();

    // Alunos
    var a1 = new Aluno { Nome = "Ana Oliveira", Email = "ana.oliveira@example.com", DataNascimento = DateTime.Parse("2002-03-15") };
    var a2 = new Aluno { Nome = "Bruno Costa", Email = "bruno.costa@example.com", DataNascimento = DateTime.Parse("2001-07-22") };
    var a3 = new Aluno { Nome = "Carla Mendes", Email = "carla.mendes@example.com", DataNascimento = DateTime.Parse("2003-01-05") };
    var a4 = new Aluno { Nome = "Diego Rocha", Email = "diego.rocha@example.com", DataNascimento = DateTime.Parse("2000-11-11") };
    var a5 = new Aluno { Nome = "Eduarda Ramos", Email = "eduarda.ramos@example.com", DataNascimento = DateTime.Parse("2002-09-02") };
    var a6 = new Aluno { Nome = "Felipe Martins", Email = "felipe.martins@example.com", DataNascimento = DateTime.Parse("2001-05-30") };
    db.Alunos.AddRange(a1, a2, a3, a4, a5, a6);
    db.SaveChanges();

    // Turmas
    var t1 = new Turma { Codigo = "CC2025A", CursoId = c1.Id, ProfessorId = p1.Id, Inicio = DateTime.Parse("2025-02-01") };
    var t2 = new Turma { Codigo = "EE2025B", CursoId = c2.Id, ProfessorId = p2.Id, Inicio = DateTime.Parse("2025-02-15") };
    var t3 = new Turma { Codigo = "ADM2025A", CursoId = c3.Id, ProfessorId = p3.Id, Inicio = DateTime.Parse("2025-03-01") };
    db.Turmas.AddRange(t1, t2, t3);
    db.SaveChanges();

    // Matriculas
    var m1 = new Matricula { AlunoId = a1.Id, TurmaId = t1.Id, DataMatricula = DateTime.Parse("2025-02-02"), Situacao = "Matriculado" };
    var m2 = new Matricula { AlunoId = a2.Id, TurmaId = t1.Id, DataMatricula = DateTime.Parse("2025-02-03"), Situacao = "Matriculado" };
    var m3 = new Matricula { AlunoId = a3.Id, TurmaId = t2.Id, DataMatricula = DateTime.Parse("2025-02-16"), Situacao = "Matriculado" };
    var m4 = new Matricula { AlunoId = a4.Id, TurmaId = t3.Id, DataMatricula = DateTime.Parse("2025-03-02"), Situacao = "Matriculado" };
    var m5 = new Matricula { AlunoId = a5.Id, TurmaId = t1.Id, DataMatricula = DateTime.Parse("2025-02-10"), Situacao = "Trancado" };
    db.Matriculas.AddRange(m1, m2, m3, m4, m5);
    db.SaveChanges();
}
