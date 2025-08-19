using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nagisa.Core.Lexing;
using Nagisa.Lox.Lexing;
using Nagisa.Lox.Tests.Common;

namespace Nagisa.Lox.Tests.Units.Lexing.Patterns
{
    [TestClass]
    public sealed class BreakPatternTest
    {
        [TestMethod]
        public void TestIsMatch()
        {
            var file = string.Empty;
            var source = "break";
            var pattern = new TextPattern("break", TokenType.BREAK);

            var expectedResult = true;

            LexingTestHelper.AssertPatternIsMatch(pattern, file, source, expectedResult);
        }

        [TestMethod]
        public void TestRun()
        {
            var file = string.Empty;
            var source = "break";
            var pattern = new TextPattern("break", TokenType.BREAK);

            var position = new SourcePosition(0, 1, 1);
            var expectedToken = new Token(file, position, TokenType.BREAK, null);
            var expectedNext = new SourcePosition(5, 1, 6);

            LexingTestHelper.AssertPatternRun(pattern, file, source, expectedToken, expectedNext);
        }
    }
}