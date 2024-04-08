using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lox.Compiler.Lexing;
using Lox.Compiler.Tests.Common;

namespace Lox.Compiler.Tests.Integration.Lexing.Patterns
{
    [TestClass]
    public sealed class LeftCurlyePatternTest
    {
        [TestMethod]
        public void TestSingle()
        {
            var file = string.Empty;
            var source = "{";

            var truthTokens = new Token[]
            {
                new Token(file, 0, TokenType.LEFT_CURLY, string.Empty),
                new Token(file, 1, TokenType.END_OF_FILE, string.Empty)
            };
            var truthSourcemap = new SourcePosition[]
            {
                new SourcePosition(file, 0, 1, 1),
                new SourcePosition(file, 1, 1, 2)
            };

            LexingTestHelper.AssertScanner(source, truthTokens, truthSourcemap);
        }

        [TestMethod]
        public void TestSurrounded()
        {
            var file = string.Empty;
            var source = " { ";

            var truthTokens = new Token[]
            {
                new Token(file, 0, TokenType.WHITESPACE, string.Empty),
                new Token(file, 1, TokenType.LEFT_CURLY, string.Empty),
                new Token(file, 2, TokenType.WHITESPACE, string.Empty),
                new Token(file, 3, TokenType.END_OF_FILE, string.Empty)
            };
            var truthSourcemap = new SourcePosition[]
            {
                new SourcePosition(file, 0, 1, 1),
                new SourcePosition(file, 1, 1, 2),
                new SourcePosition(file, 2, 1, 3),
                new SourcePosition(file, 3, 1, 4)
            };

            LexingTestHelper.AssertScanner(source, truthTokens, truthSourcemap);
        }
    }
}