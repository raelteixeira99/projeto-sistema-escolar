-- SQLite compatible script to create tables and insert sample data for SistemaEscolar


PRAGMA foreign_keys = ON;


CREATE TABLE IF NOT EXISTS Alunos (
  Id INTEGER PRIMARY KEY AUTOINCREMENT,
  Nome TEXT NOT NULL,
  DataNascimento DATE,
  Email TEXT,
  Ativo INTEGER NOT NULL DEFAULT 1
);

CREATE TABLE IF NOT EXISTS Professores (
  Id INTEGER PRIMARY KEY AUTOINCREMENT,
  Nome TEXT NOT NULL,
  Disciplina TEXT
);

CREATE TABLE IF NOT EXISTS Cursos (
  Id INTEGER PRIMARY KEY AUTOINCREMENT,
  Nome TEXT NOT NULL,
  DuracaoSemestres INTEGER NOT NULL
);

CREATE TABLE IF NOT EXISTS Turmas (
  Id INTEGER PRIMARY KEY AUTOINCREMENT,
  Codigo TEXT NOT NULL,
  CursoId INTEGER NOT NULL,
  ProfessorId INTEGER,
  Inicio DATE NOT NULL,
  Fim DATE,
  FOREIGN KEY (CursoId) REFERENCES Cursos(Id),
  FOREIGN KEY (ProfessorId) REFERENCES Professores(Id)
);

CREATE TABLE IF NOT EXISTS Matriculas (
  Id INTEGER PRIMARY KEY AUTOINCREMENT,
  AlunoId INTEGER NOT NULL,
  TurmaId INTEGER NOT NULL,
  DataMatricula DATE NOT NULL,
  Situacao TEXT NOT NULL,
  FOREIGN KEY (AlunoId) REFERENCES Alunos(Id),
  FOREIGN KEY (TurmaId) REFERENCES Turmas(Id)
);

-- Insert sample Cursos
INSERT INTO Cursos (Nome, DuracaoSemestres) VALUES ('Ciência da Computação', 8);
INSERT INTO Cursos (Nome, DuracaoSemestres) VALUES ('Engenharia Elétrica', 10);
INSERT INTO Cursos (Nome, DuracaoSemestres) VALUES ('Administração', 8);
INSERT INTO Cursos (Nome, DuracaoSemestres) VALUES ('Matemática', 6);
INSERT INTO Cursos (Nome, DuracaoSemestres) VALUES ('Pedagogia', 8);

-- Insert sample Professores
INSERT INTO Professores (Nome, Disciplina) VALUES ('Mariana Silva', 'Programação');
INSERT INTO Professores (Nome, Disciplina) VALUES ('Carlos Souza', 'Cálculo');
INSERT INTO Professores (Nome, Disciplina) VALUES ('Fernanda Lima', 'Administração');
INSERT INTO Professores (Nome, Disciplina) VALUES ('João Pereira', 'Didática');

-- Insert sample Alunos
INSERT INTO Alunos (Nome, DataNascimento, Email) VALUES ('Ana Oliveira', '2002-03-15', 'ana.oliveira@example.com');
INSERT INTO Alunos (Nome, DataNascimento, Email) VALUES ('Bruno Costa', '2001-07-22', 'bruno.costa@example.com');
INSERT INTO Alunos (Nome, DataNascimento, Email) VALUES ('Carla Mendes', '2003-01-05', 'carla.mendes@example.com');
INSERT INTO Alunos (Nome, DataNascimento, Email) VALUES ('Diego Rocha', '2000-11-11', 'diego.rocha@example.com');
INSERT INTO Alunos (Nome, DataNascimento, Email) VALUES ('Eduarda Ramos', '2002-09-02', 'eduarda.ramos@example.com');
INSERT INTO Alunos (Nome, DataNascimento, Email) VALUES ('Felipe Martins', '2001-05-30', 'felipe.martins@example.com');

-- Insert sample Turmas (assumes Cursos and Professores inserted above)
INSERT INTO Turmas (Codigo, CursoId, ProfessorId, Inicio) VALUES ('CC2025A', 1, 1, '2025-02-01');
INSERT INTO Turmas (Codigo, CursoId, ProfessorId, Inicio) VALUES ('EE2025B', 2, 2, '2025-02-15');
INSERT INTO Turmas (Codigo, CursoId, ProfessorId, Inicio) VALUES ('ADM2025A', 3, 3, '2025-03-01');

-- Insert Matriculas
INSERT INTO Matriculas (AlunoId, TurmaId, DataMatricula, Situacao) VALUES (1, 1, '2025-02-02', 'Matriculado');
INSERT INTO Matriculas (AlunoId, TurmaId, DataMatricula, Situacao) VALUES (2, 1, '2025-02-03', 'Matriculado');
INSERT INTO Matriculas (AlunoId, TurmaId, DataMatricula, Situacao) VALUES (3, 2, '2025-02-16', 'Matriculado');
INSERT INTO Matriculas (AlunoId, TurmaId, DataMatricula, Situacao) VALUES (4, 3, '2025-03-02', 'Matriculado');
INSERT INTO Matriculas (AlunoId, TurmaId, DataMatricula, Situacao) VALUES (5, 1, '2025-02-10', 'Trancado');
