using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SistemaEscolar.Models
{
    public class Professor
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Nome { get; set; }

        [StringLength(100)]
        public string Disciplina { get; set; }

        public ICollection<Turma> Turmas { get; set; }
    }
}
