using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nagisa.Lox.Lexing;
using Nagisa.Lox.Lexing.Patterns;
using Nagisa.Lox.Tests.Common;

namespace Nagisa.Lox.Tests.Integration.Lexing.Patterns
{
    [TestClass]
    public sealed class FalsePatternTest
    {
        [TestMethod]
        public void TestSingle()
        {
            var file = string.Empty;
            var source = "false";

            var expectedTokens = new Token[]
            {
                new Token(file, 0, 1, 1, TokenType.FALSE,       null),
                new Token(file, 5, 1, 6, TokenType.END_OF_FILE, null)
            };

            LexingTestHelper.AssertScanner(source, expectedTokens);
        }

        [TestMethod]
        public void TestSurrounded()
        {
            var file = string.Empty;
            var source = " false ";

            var expectedTokens = new Token[]
            {
                new Token(file, 0, 1, 1, TokenType.WHITESPACE,  null),
                new Token(file, 1, 1, 2, TokenType.FALSE,       null),
                new Token(file, 6, 1, 7, TokenType.WHITESPACE,  null),
                new Token(file, 7, 1, 8, TokenType.END_OF_FILE, null)
            };

            LexingTestHelper.AssertScanner(source, expectedTokens);
        }
    }
}