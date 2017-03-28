using System;

namespace csharp_fundamentos
{
    class Program
    {
        static void Main(string[] args)
        {
            int matricula = 10;
            string nome = "Pablo";
            string sobrenome = "Tôndolo de Vargas";
            DateTime dataNascimento = new DateTime(198, 12, 12);
            decimal salario = 1000.77M;
            bool feriasVencidas = true;
            char sexo = 'M';

            Console.WriteLine($"{nome} {sobrenome}");
        }
    }
}
