using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nagisa.Lox.Lexing;
using Nagisa.Lox.Lexing.Patterns;
using Nagisa.Lox.Tests.Common;

namespace Nagisa.Lox.Tests.Units.Lexing.Patterns
{
    [TestClass]
    public sealed class NotPatternTest
    {
        [TestMethod]
        public void TestIsMatch()
        {
            var file = string.Empty;
            var source = "!";
            var pattern = new CharacterPattern('!', TokenType.NOT);

            var expectedResult = true;

            LexingTestHelper.AssertPatternIsMatch(pattern, file, source, expectedResult);
        }

        [TestMethod]
        public void TestRun()
        {
            var file = string.Empty;
            var source = "!";
            var pattern = new CharacterPattern('!', TokenType.NOT);

            var position = new SourcePosition(0, 1, 1);
            var expectedToken = new Token(file, position, TokenType.NOT, null);
            var expectedNext = new SourcePosition(1, 1, 2);

            LexingTestHelper.AssertPatternRun(pattern, file, source, expectedToken, expectedNext);
        }
    }
}