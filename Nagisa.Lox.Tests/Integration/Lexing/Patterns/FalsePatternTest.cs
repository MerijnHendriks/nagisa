using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nagisa.Core.Lexing;
using Nagisa.Lox.Lexing;
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

            var positions = new SourcePosition[]
            {
                new SourcePosition(0, 1, 1),
                new SourcePosition(5, 1, 6)
            };
            var expectedTokens = new Token[]
            {
                new Token(file, positions[0], TokenType.FALSE,       null),
                new Token(file, positions[1], TokenType.END_OF_FILE, null)
            };

            LexingTestHelper.AssertScanner(source, expectedTokens);
        }

        [TestMethod]
        public void TestSurrounded()
        {
            var file = string.Empty;
            var source = " false ";

            var positions = new SourcePosition[]
            {
                new SourcePosition(0, 1, 1),
                new SourcePosition(1, 1, 2),
                new SourcePosition(6, 1, 7),
                new SourcePosition(7, 1, 8)
            };
            var expectedTokens = new Token[]
            {
                new Token(file, positions[0], TokenType.WHITESPACE,  null),
                new Token(file, positions[1], TokenType.FALSE,       null),
                new Token(file, positions[2], TokenType.WHITESPACE,  null),
                new Token(file, positions[3], TokenType.END_OF_FILE, null)
            };

            LexingTestHelper.AssertScanner(source, expectedTokens);
        }
    }
}