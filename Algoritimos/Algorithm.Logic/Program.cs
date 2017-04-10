
namespace Algorithm.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Program
    {
        /// <summary>
        /// PROBLEMA:
        /// 
        /// Implementar um algoritmo para o controle de posição de um drone em um plano cartesiano (X, Y).
        /// 
        /// O ponto inicial do drone é "(0, 0)" para cada execução do método Evaluate ao ser executado cada teste unitário.
        /// 
        /// A string de entrada pode conter os seguintes caracteres N, S, L, e O representando Norte, Sul, Leste e Oeste respectivamente.
        /// Estes catacteres podem estar presentes aleatóriamente na string de entrada.
        /// Uma string de entrada "NNNLLL" irá resultar em uma posição final "(3, 3)", assim como uma string "NLNLNL" irá resultar em "(3, 3)".
        /// 
        /// Caso o caracter X esteja presente, o mesmo irá cancelar a operação anterior. 
        /// Caso houver mais de um caracter X consecutivo, o mesmo cancelará mais de uma ação na quantidade em que o X estiver presente.
        /// Uma string de entrada "NNNXLLLXX" irá resultar em uma posição final "(1, 2)" pois a string poderia ser simplificada para "NNL".
        /// 
        /// Além disso, um número pode estar presente após o caracter da operação, representando o "passo" que a operação deve acumular.
		/// Este número deve estar compreendido entre 1 e 2147483647.
		/// Deve-se observar que a operação 'X' não suporta opção de "passo" e deve ser considerado inválido. Uma string de entrada "NNX2" deve ser considerada inválida.
        /// Uma string de entrada "N123LSX" irá resultar em uma posição final "(1, 123)" pois a string pode ser simplificada para "N123L"
        /// Uma string de entrada "NLS3X" irá resultar em uma posição final "(1, 1)" pois a string pode ser siplificada para "NL".
        /// 
        /// Caso a string de entrada seja inválida ou tenha algum outro problema, o resultado deve ser "(999, 999)".
        /// 
        /// OBSERVAÇÕES:
        /// Realizar uma implementação com padrões de código para ambiente de "produção". 
        /// Comentar o código explicando o que for relevânte para a solução do problema.
        /// Adicionar testes unitários para alcançar uma cobertura de testes relevânte.
        /// </summary>
        /// <param name="input">String no padrão "N1N2S3S4L5L6O7O8X"</param>
        /// <returns>String representando o ponto cartesiano após a execução dos comandos (X, Y)</returns>
        public static string Evaluate(string input)
        {
            // TODO: Este método é o ponto de entrada para a lógica.

            if (IsInvalid(input))
                return "(999, 999)";

            int norte, sul, leste, oeste;
            norte = sul = leste = oeste = 0;

            List<string> comandos = new List<string>();

            Parse(input, comandos);
            
            foreach (var comando in comandos)
            {
                string valor = Regex.Match(comando, @"\d+").Value;
                int numero = 0;

                int.TryParse(valor, out numero);

                if (numero >= 2147483647)
                    return "(999, 999)";
                
                switch (comando[0])
                {
                    case 'N':
                        norte++;
                        if (numero != 0)
                            norte += numero - 1;
                        break;
                    case 'S':
                        sul--;
                        if (numero != 0)
                            sul += numero * -1 + 1;
                        break;
                    case 'L':
                        leste++;
                        if (numero != 0)
                            leste += numero - 1;
                        break;
                    case 'O':
                        oeste--;
                        if (numero != 0)
                            oeste += numero * -1 + 1;
                        break;
                }                
            }

            int y = norte + sul;
            int x = leste + oeste;

            return $"({x}, {y})";
        }

        /// <summary>
        /// Convert o input em uma lista de comandos
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static void Parse(string input, List<string> comandos)
        {
            for (int i = 0; i < input.Length; i++)
            {
                string comando = input[i].ToString();

                if (comando == "X")
                {
                    comandos.Remove(comandos.Last());
                }
                else if (Char.IsNumber(input[i]))
                {
                    var last = comandos.Last();
                    last += input[i];

                    comandos[comandos.Count - 1] = last;
                }
                else
                {
                    comandos.Add(comando);
                }
            }
        }

        /// <summary>
        /// Verifica se a string é inválida
        /// <para>Inválida quando: vázia, nula ou iniciar por números</para>
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static bool IsInvalid(string input)
        {
            string valid = "NSLOX0123456789";


            return string.IsNullOrWhiteSpace(input) ||
               Regex.IsMatch(input, @"^\d+") ||               
               (input.Contains("X") && !input.EndsWith("X") && Char.IsNumber(input[input.IndexOf("X") + 1])) ||
               input.ToArray().Any(i => !valid.Contains(i));
        }
    }
}
