using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nagisa.Core.Lexing;
using Nagisa.Lox.Lexing;
using Nagisa.Lox.Tests.Common;

namespace Nagisa.Lox.Tests.Units.Lexing.Patterns
{
    [TestClass]
    public sealed class MinusPatternTest
    {
        [TestMethod]
        public void TestIsMatch()
        {
            var file = string.Empty;
            var source = "-";
            var pattern = new CharacterPattern('-', TokenType.MINUS);

            var expectedResult = true;

            LexingTestHelper.AssertPatternIsMatch(pattern, file, source, expectedResult);
        }

        [TestMethod]
        public void TestRun()
        {
            var file = string.Empty;
            var source = "-";
            var pattern = new CharacterPattern('-', TokenType.MINUS);

            var position = new SourcePosition(0, 1, 1);
            var expectedToken = new Token(file, position, TokenType.MINUS, null);
            var expectedNext = new SourcePosition(1, 1, 2);

            LexingTestHelper.AssertPatternRun(pattern, file, source, expectedToken, expectedNext);
        }
    }
}