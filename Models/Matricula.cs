using System;
using System.ComponentModel.DataAnnotations;

namespace SistemaEscolar.Models
{
    public class Matricula
    {
        public int Id { get; set; }

        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; }

        public int TurmaId { get; set; }
        public Turma Turma { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataMatricula { get; set; } = DateTime.Now;

        [StringLength(20)]
        public string Situacao { get; set; } = "Matriculado";
    }
}
