using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebCore.Models.PessoaViewModels
{
    public class Pessoa
    {
        [Required]
        [MaxLength(30)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(30)]
        public String UltimoNome { get; set; }

        public bool IsEstudante { get; set; }
        
        [Required]        
        public DateTime DataNascimento { get; set; }
    }
}
