using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lox.Compiler.Lexing;
using Lox.Compiler.Language.Lexing;
using Lox.Compiler.Tests.Common;

namespace Lox.Compiler.Tests.Integration.Lexing.Patterns
{
    [TestClass]
    public sealed class NotEqualAssignPatternTest
    {
        [TestMethod]
        public void TestSingle()
        {
            var file = string.Empty;
            var source = "!=";

            var expectedTokens = new Token[]
            {
                new Token(file, 0, TokenType.NOT_EQUAL, null),
                new Token(file, 2, TokenType.END_OF_FILE, null)
            };
            var expectedSourcemap = new SourcePosition[]
            {
                new SourcePosition(file, 0, 1, 1),
                new SourcePosition(file, 2, 1, 3)
            };

            LexingTestHelper.AssertScanner(source, expectedTokens, expectedSourcemap);
        }

        [TestMethod]
        public void TestSurrounded()
        {
            var file = string.Empty;
            var source = " != ";

            var expectedTokens = new Token[]
            {
                new Token(file, 0, TokenType.WHITESPACE, null),
                new Token(file, 1, TokenType.NOT_EQUAL, null),
                new Token(file, 3, TokenType.WHITESPACE, null),
                new Token(file, 4, TokenType.END_OF_FILE, null)
            };
            var expectedSourcemap = new SourcePosition[]
            {
                new SourcePosition(file, 0, 1, 1),
                new SourcePosition(file, 1, 1, 2),
                new SourcePosition(file, 3, 1, 4),
                new SourcePosition(file, 4, 1, 5)
            };

            LexingTestHelper.AssertScanner(source, expectedTokens, expectedSourcemap);
        }
    }
}