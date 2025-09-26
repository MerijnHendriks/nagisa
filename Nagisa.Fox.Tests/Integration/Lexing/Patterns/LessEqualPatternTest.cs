using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nagisa.Fox.Lexing;
using Nagisa.Fox.Tests.Common;

namespace Nagisa.Fox.Tests.Integration.Lexing.Patterns
{
    [TestClass]
    public sealed class LessEqualPatternTest
    {
        [TestMethod]
        public void TestSingle()
        {
            var file = string.Empty;
            var source = "<=";

            var expectedTokens = new Token[]
            {
                new Token(file, 0, 1, 1, TokenType.LESS_EQUAL,  null),
                new Token(file, 2, 1, 3, TokenType.END_OF_FILE, null)
            };

            LexingTestHelper.AssertScanner(source, expectedTokens);
        }

        [TestMethod]
        public void TestSurrounded()
        {
            var file = string.Empty;
            var source = " <= ";

            var expectedTokens = new Token[]
            {
                new Token(file, 0, 1, 1, TokenType.WHITESPACE,  null),
                new Token(file, 1, 1, 2, TokenType.LESS_EQUAL,  null),
                new Token(file, 3, 1, 4, TokenType.WHITESPACE,  null),
                new Token(file, 4, 1, 5, TokenType.END_OF_FILE, null)
            };

            LexingTestHelper.AssertScanner(source, expectedTokens);
        }
    }
}