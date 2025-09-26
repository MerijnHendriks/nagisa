using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nagisa.Fox.Lexing;
using Nagisa.Fox.Tests.Common;

namespace Nagisa.Fox.Tests.Units.Lexing.Patterns
{
    [TestClass]
    public sealed class RightCirclePatternTest
    {
        [TestMethod]
        public void TestIsMatch()
        {
            var file = string.Empty;
            var source = ")";
            var pattern = new CharacterPattern(')', TokenType.RIGHT_CIRCLE);

            var expectedResult = true;

            LexingTestHelper.AssertPatternIsMatch(pattern, file, source, expectedResult);
        }

        [TestMethod]
        public void TestRun()
        {
            var file = string.Empty;
            var source = ")";
            var pattern = new CharacterPattern(')', TokenType.RIGHT_CIRCLE);

            var position = new SourcePosition(0, 1, 1);
            var expectedToken = new Token(file, position, TokenType.RIGHT_CIRCLE, null);
            var expectedNext = new SourcePosition(1, 1, 2);

            LexingTestHelper.AssertPatternRun(pattern, file, source, expectedToken, expectedNext);
        }
    }
}