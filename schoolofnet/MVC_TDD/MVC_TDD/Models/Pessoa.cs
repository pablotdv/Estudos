namespace MVC_TDD.Models
{
    public class Pessoa
    {    
        public Pessoa(string cpf, string nome)
        {
            if (string.IsNullOrWhiteSpace(cpf))
                throw new System.Exception("CPF deve ser preenchido");

            if (string.IsNullOrWhiteSpace(nome))
                throw new System.Exception("Nome deve ser preenchido");

            this.Cpf = cpf;
            this.Nome = nome;
        }

        public string Nome { get; set; }
        public string Cpf { get; set; }
    }
}