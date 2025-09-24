using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nagisa.Fox.Lexing;
using Nagisa.Fox.Lexing.Patterns;
using Nagisa.Fox.Tests.Common;

namespace Nagisa.Fox.Tests.Integration.Lexing.Patterns
{
    [TestClass]
    public sealed class WhitespacePatternTest
    {
        [TestMethod]
        public void TestSingle()
        {
            var file = string.Empty;
            var source = " ";

            var expectedTokens = new Token[]
            {
                new Token(file, 0, 1, 1, TokenType.WHITESPACE,  null),
                new Token(file, 1, 1, 2, TokenType.END_OF_FILE, null)
            };

            LexingTestHelper.AssertScanner(source, expectedTokens);
        }

        [TestMethod]
        public void TestSurrounded()
        {
            var file = string.Empty;
            var source = "   ";

            var expectedTokens = new Token[]
            {
                new Token(file, 0, 1, 1, TokenType.WHITESPACE,  null),
                new Token(file, 1, 1, 2, TokenType.WHITESPACE,  null),
                new Token(file, 2, 1, 3, TokenType.WHITESPACE,  null),
                new Token(file, 3, 1, 4, TokenType.END_OF_FILE, null)
            };

            LexingTestHelper.AssertScanner(source, expectedTokens);
        }
    }
}