using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lox.Compiler.Lexing;
using Lox.Compiler.Tests.Common;

namespace Lox.Compiler.Tests.Integration.Lexing.Patterns
{
    [TestClass]
    public sealed class AndPatternTest
    {
        [TestMethod]
        public void TestSingle()
        {
            var file = string.Empty;
            var source = "and";

            var expectedTokens = new Token[]
            {
                new Token(file, 0, TokenType.AND, string.Empty),
                new Token(file, 3, TokenType.END_OF_FILE, string.Empty)
            };
            var expectedSourcemap = new SourcePosition[]
            {
                new SourcePosition(file, 0, 1, 1),
                new SourcePosition(file, 3, 1, 4)
            };

            LexingTestHelper.AssertScanner(source, expectedTokens, expectedSourcemap);
        }

        [TestMethod]
        public void TestSurrounded()
        {
            var file = string.Empty;
            var source = " and ";

            var expectedTokens = new Token[]
            {
                new Token(file, 0, TokenType.WHITESPACE, string.Empty),
                new Token(file, 1, TokenType.AND, string.Empty),
                new Token(file, 4, TokenType.WHITESPACE, string.Empty),
                new Token(file, 5, TokenType.END_OF_FILE, string.Empty)
            };
            var expectedSourcemap = new SourcePosition[]
            {
                new SourcePosition(file, 0, 1, 1),
                new SourcePosition(file, 1, 1, 2),
                new SourcePosition(file, 4, 1, 5),
                new SourcePosition(file, 5, 1, 6)
            };

            LexingTestHelper.AssertScanner(source, expectedTokens, expectedSourcemap);
        }
    }
}