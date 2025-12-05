using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SistemaEscolar.Models
{
    public class Turma
    {
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Codigo { get; set; }

        public int CursoId { get; set; }
        public Curso Curso { get; set; }

        public int? ProfessorId { get; set; }
        public Professor Professor { get; set; }

        [DataType(DataType.Date)]
        public DateTime Inicio { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Fim { get; set; }

        public ICollection<Matricula> Matriculas { get; set; }
    }
}
