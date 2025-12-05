using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SistemaEscolar.Models
{
    public class Curso
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Nome { get; set; }

        public int DuracaoSemestres { get; set; }

        public ICollection<Turma> Turmas { get; set; }
    }
}
