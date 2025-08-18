using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lox.Compiler.Lexing;
using Lox.Compiler.Language.Lexing;
using Lox.Compiler.Tests.Common;

namespace Lox.Compiler.Tests.Integration.Lexing.Patterns
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
                new Token(file, 0, TokenType.FALSE,       null),
                new Token(file, 5, TokenType.END_OF_FILE, null)
            };
            var expectedSourcemap = new SourcePosition[]
            {
                new SourcePosition(file, 0, 1, 1),
                new SourcePosition(file, 5, 1, 6)
            };

            LexingTestHelper.AssertScanner(source, expectedTokens, expectedSourcemap);
        }

        [TestMethod]
        public void TestSurrounded()
        {
            var file = string.Empty;
            var source = " false ";

            var expectedTokens = new Token[]
            {
                new Token(file, 0, TokenType.WHITESPACE,  null),
                new Token(file, 1, TokenType.FALSE,       null),
                new Token(file, 6, TokenType.WHITESPACE,  null),
                new Token(file, 7, TokenType.END_OF_FILE, null)
            };
            var expectedSourcemap = new SourcePosition[]
            {
                new SourcePosition(file, 0, 1, 1),
                new SourcePosition(file, 1, 1, 2),
                new SourcePosition(file, 6, 1, 7),
                new SourcePosition(file, 7, 1, 8)
            };

            LexingTestHelper.AssertScanner(source, expectedTokens, expectedSourcemap);
        }
    }
}