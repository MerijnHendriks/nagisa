using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lox.Compiler.Lexing;
using Lox.Compiler.Lexing.Patterns;
using Lox.Compiler.Tests.Common;

namespace Lox.Compiler.Tests.Integration.Lexing.Patterns
{
    [TestClass]
    public sealed class SubstractAssignPatternTest
    {
        private readonly LexingTestHelper _helper;

        public SubstractAssignPatternTest()
        {
            _helper = new LexingTestHelper();
        }

        [TestMethod]
        public void TestSingle()
        {
            var file = string.Empty;
            var source = "-=";
            var tokens = new Token[]
            {
                new Token(file, 0, TokenType.SUBSTRACT_ASSIGN, string.Empty),
                new Token(file, 2, TokenType.END_OF_FILE, string.Empty)
            };
            var sourcemap = new SourcePosition[]
            {
                new SourcePosition(file, 0, 1, 1),
                new SourcePosition(file, 2, 1, 3)
            };

            _helper.AssertScanner(source, tokens, sourcemap);
        }

        [TestMethod]
        public void TestSurrounded()
        {
            var file = string.Empty;
            var source = " -= ";
            var tokens = new Token[]
            {
                new Token(file, 0, TokenType.WHITESPACE, string.Empty),
                new Token(file, 1, TokenType.SUBSTRACT_ASSIGN, string.Empty),
                new Token(file, 3, TokenType.WHITESPACE, string.Empty),
                new Token(file, 4, TokenType.END_OF_FILE, string.Empty)
            };
            var sourcemap = new SourcePosition[]
            {
                new SourcePosition(file, 0, 1, 1),
                new SourcePosition(file, 1, 1, 2),
                new SourcePosition(file, 3, 1, 4),
                new SourcePosition(file, 4, 1, 5)
            };

            _helper.AssertScanner(source, tokens, sourcemap);
        }
    }
}