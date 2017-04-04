using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVC_TDD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_TDD.Tests
{
    [TestClass]
    public class PessoaTeste
    {
        [TestMethod]
        public void PessoaDeveTerCpfENome()
        {
            string cpf = "99999999999";
            string nome = "Pablo Tôndolo de Vargas";

            Pessoa pessoa = new Pessoa(cpf, nome);
            Assert.IsTrue(!String.IsNullOrWhiteSpace(pessoa.Cpf), "CPF nulo ou embranco");
            Assert.IsTrue(!String.IsNullOrWhiteSpace(pessoa.Nome), "Nome nulo ou embranco");

            Assert.AreEqual(cpf, pessoa.Cpf);
            Assert.AreEqual(nome, pessoa.Nome);
        }

        [TestMethod]
        public void CPFDeveSerValido()
        {
            //string cpf = "99999999999";
        }
    }
}
