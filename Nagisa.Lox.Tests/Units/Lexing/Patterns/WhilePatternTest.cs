using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nagisa.Lox.Lexing;
using Nagisa.Lox.Lexing.Patterns;
using Nagisa.Lox.Tests.Common;

namespace Nagisa.Lox.Tests.Units.Lexing.Patterns
{
    [TestClass]
    public sealed class WhilePatternTest
    {
        [TestMethod]
        public void TestIsMatch()
        {
            var file = string.Empty;
            var source = "while";
            var pattern = new TextPattern("while", TokenType.WHILE);

            var expectedResult = true;

            LexingTestHelper.AssertPatternIsMatch(pattern, file, source, expectedResult);
        }

        [TestMethod]
        public void TestRun()
        {
            var file = string.Empty;
            var source = "while";
            var pattern = new TextPattern("while", TokenType.WHILE);

            var position = new SourcePosition(0, 1, 1);
            var expectedToken = new Token(file, position, TokenType.WHILE, null);
            var expectedNext = new SourcePosition(5, 1, 6);

            LexingTestHelper.AssertPatternRun(pattern, file, source, expectedToken, expectedNext);
        }
    }
}