using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace SistemaEscolar.Models
{
    public class Aluno
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Nome { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DataNascimento { get; set; }

        [EmailAddress, StringLength(200)]
        public string Email { get; set; }

        public bool Ativo { get; set; } = true;

        public ICollection<Matricula> Matriculas { get; set; }
    }
}
