using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nagisa.Core.Lexing;
using Nagisa.Lox.Lexing;
using Nagisa.Lox.Tests.Common;

namespace Nagisa.Lox.Tests.Integration.Lexing.Patterns
{
    [TestClass]
    public sealed class EqualAssignPatternTest
    {
        [TestMethod]
        public void TestSingle()
        {
            var file = string.Empty;
            var source = "==";

            var positions = new SourcePosition[]
            {
                new SourcePosition(0, 1, 1),
                new SourcePosition(2, 1, 3)
            };
            var expectedTokens = new Token[]
            {
                new Token(file, positions[0], TokenType.EQUAL,       null),
                new Token(file, positions[1], TokenType.END_OF_FILE, null)
            };

            LexingTestHelper.AssertScanner(source, expectedTokens);
        }

        [TestMethod]
        public void TestSurrounded()
        {
            var file = string.Empty;
            var source = " == ";

            var positions = new SourcePosition[]
            {
                new SourcePosition(0, 1, 1),
                new SourcePosition(1, 1, 2),
                new SourcePosition(3, 1, 4),
                new SourcePosition(4, 1, 5)
            };
            var expectedTokens = new Token[]
            {
                new Token(file, positions[0], TokenType.WHITESPACE,  null),
                new Token(file, positions[1], TokenType.EQUAL,       null),
                new Token(file, positions[2], TokenType.WHITESPACE,  null),
                new Token(file, positions[3], TokenType.END_OF_FILE, null)
            };

            LexingTestHelper.AssertScanner(source, expectedTokens);
        }
    }
}