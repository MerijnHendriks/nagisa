using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nagisa.Core.Lexing;
using Nagisa.Lox.Lexing;
using Nagisa.Lox.Tests.Common;

namespace Nagisa.Lox.Tests.Integration.Lexing.Patterns
{
    [TestClass]
    public sealed class ContinuePatternTest
    {
        [TestMethod]
        public void TestSingle()
        {
            var file = string.Empty;
            var source = "continue";

            var expectedTokens = new Token[]
            {
                new Token(file, 0, 1, 1, TokenType.CONTINUE,    null),
                new Token(file, 8, 1, 9, TokenType.END_OF_FILE, null)
            };

            LexingTestHelper.AssertScanner(source, expectedTokens);
        }

        [TestMethod]
        public void TestSurrounded()
        {
            var file = string.Empty;
            var source = " continue ";

            var expectedTokens = new Token[]
            {
                new Token(file, 0,  1, 1,  TokenType.WHITESPACE,  null),
                new Token(file, 1,  1, 2,  TokenType.CONTINUE,    null),
                new Token(file, 9,  1, 10, TokenType.WHITESPACE,  null),
                new Token(file, 10, 1, 11, TokenType.END_OF_FILE, null)
            };

            LexingTestHelper.AssertScanner(source, expectedTokens);
        }
    }
}