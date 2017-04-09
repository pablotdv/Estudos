using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Algorithm.Logic.Tests
{
    [TestClass]
    public class DroneUnitTest
    {
        [TestMethod]
        public void Input_NNNNNLLLLL()
        {
            Assert.AreEqual("(5, 5)", Program.Evaluate("NNNNNLLLLL"));
        }

        [TestMethod]
        public void Input_NLNLNLNLNL()
        {
            Assert.AreEqual("(5, 5)", Program.Evaluate("NLNLNLNLNL"));
        }

        [TestMethod]
        public void Input_NNNNNXLLLLLX()
        {
            Assert.AreEqual("(4, 4)", Program.Evaluate("NNNNNXLLLLLX"));
        }

        [TestMethod]
        public void Input_SSSSSOOOOO()
        {
            Assert.AreEqual("(-5, -5)", Program.Evaluate("SSSSSOOOOO"));
        }

        [TestMethod]
        public void Input_S5O5()
        {
            Assert.AreEqual("(-5, -5)", Program.Evaluate("S5O5"));
        }

        [TestMethod]
        public void Input_NNX2()
        {
            Assert.AreEqual("(999, 999)", Program.Evaluate("NNX2"));
        }

        [TestMethod]
        public void Input_N123LSX()
        {
            Assert.AreEqual("(1, 123)", Program.Evaluate("N123LSX"));
        }

        [TestMethod]
        public void Input_NLS3X()
        {
            Assert.AreEqual("(1, 1)", Program.Evaluate("NLS3X"));
        }

        [TestMethod]
        public void Input_NNNXLLLXX()
        {
            Assert.AreEqual("(1, 2)", Program.Evaluate("NNNXLLLXX"));
        }

        [TestMethod]
        public void Input_N40L30S20O10NLSOXX()
        {
            Assert.AreEqual("(21, 21)", Program.Evaluate("N40L30S20O10NLSOXX"));
        }

        [TestMethod]
        public void Input_NLSOXXN40L30S20O10()
        {
            Assert.AreEqual("(21, 21)", Program.Evaluate("NLSOXXN40L30S20O10"));
        }

        [TestMethod]
        public void Input_NULL()
        {
            Assert.AreEqual("(999, 999)", Program.Evaluate(null)); // Entrada nula
        }

        [TestMethod]
        public void Input_EMPTY()
        {
            Assert.AreEqual("(999, 999)", Program.Evaluate("")); // Entrada vazia
        }

        [TestMethod]
        public void Input_WHITESPACE()
        {
            Assert.AreEqual("(999, 999)", Program.Evaluate("   ")); // Entrada espaço vazio
        }

        [TestMethod]
        public void Input_123()
        {
            Assert.AreEqual("(999, 999)", Program.Evaluate("123")); // Entrada inválida
        }

        [TestMethod]
        public void Input_123N()
        {
            Assert.AreEqual("(999, 999)", Program.Evaluate("123N")); // passos antes da direçao
        }

        [TestMethod]
        public void Input_N2147483647N()
        {
            Assert.AreEqual("(999, 999)", Program.Evaluate("N2147483647N")); // Overflow
        }

        [TestMethod]
        public void Input_NNI()
        {
            Assert.AreEqual("(999, 999)", Program.Evaluate("NNI")); // Commando inválido
        }

        [TestMethod]
        public void Input_N2147483647XN()
        {
            Assert.AreEqual("(0, 1)", Program.Evaluate("N2147483647XN")); // Overflow cancelado
        }

        [TestMethod]
        public void Input_BIGSTRING()
        {
            Assert.AreEqual("(500, 500)", Program.Evaluate(new string(
                Enumerable.Repeat('N', 1000).Concat(
                Enumerable.Repeat('S', 500)).Concat(
                Enumerable.Repeat('L', 1000)).Concat(
                Enumerable.Repeat('O', 500)).ToArray())));
        }

        [TestMethod]
        public void Input_N20S15()
        {
            Assert.AreEqual("(0, 5)", Program.Evaluate("N20S15"));
        }

        [TestMethod]
        public void Parse_NNLL()
        {
            List<string> comandos = new List<string>();
            Program.Parse("NNLL", comandos);
            Assert.AreEqual("N", comandos[0]);
            Assert.AreEqual("N", comandos[1]);
            Assert.AreEqual("L", comandos[2]);
            Assert.AreEqual("L", comandos[3]);
        }

        [TestMethod]
        public void Parse_N10LLO20()
        {
            List<string> comandos = new List<string>();
            Program.Parse("N10LLO20", comandos);
            Assert.AreEqual("N10", comandos[0]);
            Assert.AreEqual("L", comandos[1]);
            Assert.AreEqual("L", comandos[2]);
            Assert.AreEqual("O20", comandos[3]);
        }

        [TestMethod]
        public void Parse_NLS3X()
        {
            List<string> comandos = new List<string>();
            Program.Parse("NLS3X", comandos);
            Assert.AreEqual("N", comandos[0]);
            Assert.AreEqual("L", comandos[1]);
        }

        [TestMethod]
        public void Parse_N10XLS3X()
        {
            List<string> comandos = new List<string>();
            Program.Parse("N10XLS3X", comandos);
            Assert.AreEqual("L", comandos[0]);
        }

        [TestMethod]
        public void Parse_N40L30S20O10NLSOXX()
        {
            List<string> comandos = new List<string>();
            Program.Parse("N40L30S20O10NLSOXX", comandos);
            Assert.AreEqual("N40", comandos[0]);
            Assert.AreEqual("L30", comandos[1]);
            Assert.AreEqual("S20", comandos[2]);
            Assert.AreEqual("O10", comandos[3]);
            Assert.AreEqual("N", comandos[4]);
            Assert.AreEqual("L", comandos[5]);
        }
    }
}
