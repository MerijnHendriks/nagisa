using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nagisa.Fox.Lexing;

namespace Nagisa.Fox.Tests.Units.Lexing.Patterns
{
    [TestClass]
    public sealed class TextHelperTest
    {
        [TestMethod]
        [DataRow("a", 0, false)]
        [DataRow("a", 1, true)]
        public void TestIsAtEnd(string source, int index, bool expected)
        {
            var helper = new TextHelper();
            var result = helper.IsAtEnd(source, index);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("a",  0, 'a', true)]
        [DataRow("a",  0, 'b', false)]
        [DataRow("a",  1, 'a', false)]
        public void TestIsMatchChar(string source, int index, char target, bool expected)
        {
            var helper = new TextHelper();
            var result = helper.IsMatchChar(source, index, target);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("ab", 0, "ab", true)]
        [DataRow("ab", 1, "ab", false)]
        [DataRow("ab", 0, "b",  false)]
        [DataRow("ab", 1, "a",  false)]
        public void TestIsMatchString(string source, int index, string target, bool expected)
        {
            var helper = new TextHelper();
            var result = helper.IsMatchString(source, index, target);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("a", 0, new char[] { 'a', 'b' }, true)]
        [DataRow("a", 0, new char[] { 'b', 'c' }, false)]
        [DataRow("a", 1, new char[] { 'a', 'b' }, false)]
        public void TestIsMatchCharArray(string source, int index, char[] targets, bool expected)
        {
            var helper = new TextHelper();
            var result = helper.IsMatchCharArray(source, index, targets);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("\r",  0, true)]
        [DataRow("a",   0, false)]
        [DataRow("a\r", 0, false)]
        [DataRow("\ra", 1, false)]
        public void TestIsCarriageReturn(string source, int index, bool expected)
        {
            var helper = new TextHelper();
            var result = helper.IsCarriageReturn(source, index);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("\n",  0, true)]
        [DataRow("a",   0, false)]
        [DataRow("a\n", 0, false)]
        [DataRow("\na", 1, false)]
        public void TestIsLineFeed(string source, int index, bool expected)
        {
            var helper = new TextHelper();
            var result = helper.IsLineFeed(source, index);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("\r\n",  0, true)]
        [DataRow("\r\n",  1, false)]
        [DataRow("a",     0, false)]
        [DataRow("a\r\n", 0, false)]
        public void TestIsNewLine(string source, int index, bool expected)
        {
            var helper = new TextHelper();
            var result = helper.IsNewLine(source, index);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("A", 0, true)]
        [DataRow("B", 0, true)]
        [DataRow("C", 0, true)]
        [DataRow("D", 0, true)]
        [DataRow("E", 0, true)]
        [DataRow("F", 0, true)]
        [DataRow("G", 0, true)]
        [DataRow("H", 0, true)]
        [DataRow("I", 0, true)]
        [DataRow("J", 0, true)]
        [DataRow("K", 0, true)]
        [DataRow("L", 0, true)]
        [DataRow("M", 0, true)]
        [DataRow("N", 0, true)]
        [DataRow("O", 0, true)]
        [DataRow("P", 0, true)]
        [DataRow("Q", 0, true)]
        [DataRow("R", 0, true)]
        [DataRow("S", 0, true)]
        [DataRow("T", 0, true)]
        [DataRow("U", 0, true)]
        [DataRow("V", 0, true)]
        [DataRow("W", 0, true)]
        [DataRow("X", 0, true)]
        [DataRow("Y", 0, true)]
        [DataRow("Z", 0, true)]
        [DataRow("a", 0, false)]
        [DataRow("b", 0, false)]
        [DataRow("c", 0, false)]
        [DataRow("d", 0, false)]
        [DataRow("e", 0, false)]
        [DataRow("f", 0, false)]
        [DataRow("g", 0, false)]
        [DataRow("h", 0, false)]
        [DataRow("i", 0, false)]
        [DataRow("j", 0, false)]
        [DataRow("k", 0, false)]
        [DataRow("l", 0, false)]
        [DataRow("m", 0, false)]
        [DataRow("n", 0, false)]
        [DataRow("o", 0, false)]
        [DataRow("p", 0, false)]
        [DataRow("q", 0, false)]
        [DataRow("r", 0, false)]
        [DataRow("s", 0, false)]
        [DataRow("t", 0, false)]
        [DataRow("u", 0, false)]
        [DataRow("v", 0, false)]
        [DataRow("w", 0, false)]
        [DataRow("x", 0, false)]
        [DataRow("y", 0, false)]
        [DataRow("z", 0, false)]
        public void TestIsAlphaUpper(string source, int index, bool expected)
        {
            var helper = new TextHelper();
            var result = helper.IsAlphaUpper(source, index);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("a", 0, true)]
        [DataRow("b", 0, true)]
        [DataRow("c", 0, true)]
        [DataRow("d", 0, true)]
        [DataRow("e", 0, true)]
        [DataRow("f", 0, true)]
        [DataRow("g", 0, true)]
        [DataRow("h", 0, true)]
        [DataRow("i", 0, true)]
        [DataRow("j", 0, true)]
        [DataRow("k", 0, true)]
        [DataRow("l", 0, true)]
        [DataRow("m", 0, true)]
        [DataRow("n", 0, true)]
        [DataRow("o", 0, true)]
        [DataRow("p", 0, true)]
        [DataRow("q", 0, true)]
        [DataRow("r", 0, true)]
        [DataRow("s", 0, true)]
        [DataRow("t", 0, true)]
        [DataRow("u", 0, true)]
        [DataRow("v", 0, true)]
        [DataRow("w", 0, true)]
        [DataRow("x", 0, true)]
        [DataRow("y", 0, true)]
        [DataRow("z", 0, true)]
        [DataRow("A", 0, false)]
        [DataRow("B", 0, false)]
        [DataRow("C", 0, false)]
        [DataRow("D", 0, false)]
        [DataRow("E", 0, false)]
        [DataRow("F", 0, false)]
        [DataRow("G", 0, false)]
        [DataRow("H", 0, false)]
        [DataRow("I", 0, false)]
        [DataRow("J", 0, false)]
        [DataRow("K", 0, false)]
        [DataRow("L", 0, false)]
        [DataRow("M", 0, false)]
        [DataRow("N", 0, false)]
        [DataRow("O", 0, false)]
        [DataRow("P", 0, false)]
        [DataRow("Q", 0, false)]
        [DataRow("R", 0, false)]
        [DataRow("S", 0, false)]
        [DataRow("T", 0, false)]
        [DataRow("U", 0, false)]
        [DataRow("V", 0, false)]
        [DataRow("W", 0, false)]
        [DataRow("X", 0, false)]
        [DataRow("Y", 0, false)]
        [DataRow("Z", 0, false)]
        public void TestIsAlphaLower(string source, int index, bool expected)
        {
            var helper = new TextHelper();
            var result = helper.IsAlphaLower(source, index);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("0", 0, true)]
        [DataRow("1", 0, true)]
        [DataRow("2", 0, true)]
        [DataRow("3", 0, true)]
        [DataRow("4", 0, true)]
        [DataRow("5", 0, true)]
        [DataRow("6", 0, true)]
        [DataRow("7", 0, true)]
        [DataRow("8", 0, true)]
        [DataRow("9", 0, true)]
        [DataRow("a", 0, false)]
        public void TestIsDigit(string source, int index, bool expected)
        {
            var helper = new TextHelper();
            var result = helper.IsDigit(source, index);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("camelCase",    0, true)]
        [DataRow("_camelCase",   0, true)]
        [DataRow("_camelCase1",  0, true)]
        [DataRow("_1camelCase",  0, true)]
        [DataRow("1camelCase",   0, true)]
        [DataRow("PascalCase",   0, true)]
        [DataRow("_PascalCase",  0, true)]
        [DataRow("_PascalCase1", 0, true)]
        [DataRow("_1PascalCase", 0, true)]
        [DataRow("1PascalCase",  0, true)]
        [DataRow("SNAKE_CASE",   0, true)]
        [DataRow("_SNAKE_CASE",  0, true)]
        [DataRow("_SNAKE_CASE1", 0, true)]
        [DataRow("_1SNAKE_CASE", 0, true)]
        [DataRow("1SNAKE_CASE",  0, true)]
        [DataRow("1_",           0, true)]
        public void TestIsIdentifier(string source, int index, bool expected)
        {
            var helper = new TextHelper();
            var result = helper.IsIdentifier(source, index);
            Assert.AreEqual(expected, result);
        }
    }
}