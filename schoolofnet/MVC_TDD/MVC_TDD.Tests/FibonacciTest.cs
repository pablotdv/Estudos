using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_TDD.Tests
{
    [TestClass]
    public class FibonacciTest
    {
        int[] posicao = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
        int[] numeros = new int[] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89 };

        [TestMethod]
        public void OPrimeiroElementoDeveSer0()
        {
            var result = Fibonacci.Elemento(0);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void OSegundoElementoDeveSer1()
        {
            var result = Fibonacci.Elemento(1);

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void OSetimoElementoDeveSer13()
        {
            var result = Fibonacci.Elemento(7);

            Assert.AreEqual(13, result);
        }

        [TestMethod]
        public void Testa_da_posicao_0_a_10()
        {
            for (int i = 0; i < posicao.Count(); i++)
            {
                Assert.AreEqual(numeros[i], Fibonacci.Elemento(posicao[i]));
            }
        }
    }

    public class Fibonacci
    {
        public static int Elemento(int posicao)
        {
            if (posicao < 0)
                throw new Exception("Deve ser maior que zero");

            if (posicao < 2) return posicao;

            return Elemento(posicao - 2) + Elemento(posicao - 1);
        }
    }
}
