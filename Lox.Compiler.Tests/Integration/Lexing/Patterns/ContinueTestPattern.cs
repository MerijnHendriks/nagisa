using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lox.Compiler.Lexing;
using Lox.Compiler.Tests.Common;

namespace Lox.Compiler.Tests.Integration.Lexing.Patterns
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
                new Token(file, 0, TokenType.CONTINUE,    null),
                new Token(file, 8, TokenType.END_OF_FILE, null)
            };
            var expectedSourcemap = new SourcePosition[]
            {
                new SourcePosition(file, 0, 1, 1),
                new SourcePosition(file, 8, 1, 9)
            };

            LexingTestHelper.AssertScanner(source, expectedTokens, expectedSourcemap);
        }

        [TestMethod]
        public void TestSurrounded()
        {
            var file = string.Empty;
            var source = " continue ";

            var expectedTokens = new Token[]
            {
                new Token(file, 0,  TokenType.WHITESPACE,  null),
                new Token(file, 1,  TokenType.CONTINUE,    null),
                new Token(file, 9,  TokenType.WHITESPACE,  null),
                new Token(file, 10, TokenType.END_OF_FILE, null)
            };
            var expectedSourcemap = new SourcePosition[]
            {
                new SourcePosition(file, 0,  1, 1),
                new SourcePosition(file, 1,  1, 2),
                new SourcePosition(file, 9,  1, 10),
                new SourcePosition(file, 10, 1, 11)
            };

            LexingTestHelper.AssertScanner(source, expectedTokens, expectedSourcemap);
        }
    }
}