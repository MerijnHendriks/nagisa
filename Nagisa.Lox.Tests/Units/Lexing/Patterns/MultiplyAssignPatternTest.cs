using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nagisa.Core.Lexing;
using Nagisa.Lox.Lexing;
using Nagisa.Lox.Tests.Common;

namespace Nagisa.Lox.Tests.Units.Lexing.Patterns
{
    [TestClass]
    public sealed class MultiplyAssignPatternTest
    {
        [TestMethod]
        public void TestIsMatch()
        {
            var file = string.Empty;
            var source = "*=";
            var pattern = new TextPattern("*=", TokenType.MULTIPLY_ASSIGN);

            var expectedResult = true;

            LexingTestHelper.AssertPatternIsMatch(pattern, file, source, expectedResult);
        }

        [TestMethod]
        public void TestRun()
        {
            var file = string.Empty;
            var source = "*=";
            var pattern = new TextPattern("*=", TokenType.MULTIPLY_ASSIGN);

            var position = new SourcePosition(0, 1, 1);
            var expectedToken = new Token(file, position, TokenType.MULTIPLY_ASSIGN, null);
            var expectedNext = new SourcePosition(2, 1, 3);

            LexingTestHelper.AssertPatternRun(pattern, file, source, expectedToken, expectedNext);
        }
    }
}