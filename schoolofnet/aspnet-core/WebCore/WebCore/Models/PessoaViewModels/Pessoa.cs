using Microsoft.AspNetCore.Mvc.ModelBinding;
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
        [MaxLength(30, ErrorMessage ="Máximo de 30 caracteres")]
        [BindRequired]
        public string Nome { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "Máximo de 30 caracteres")]
        [BindRequired]
        public String UltimoNome { get; set; }

        [Required]
        [BindRequired]
        public DateTime DataNascimento { get; set; }

        public bool IsEstudante { get; set; }

        //[Compare(nameof(Propriedade2))]
        //public string Propriedade { get; set; }
        //public string Propriedade2 { get; set; }

        //[Range(0,100, ErrorMessage ="Valor deve estar entre 0 e 100.")]
        //public decimal Numero { get; set; }
    }
}
