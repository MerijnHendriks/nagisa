using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nagisa.Fox.Lexing;
using Nagisa.Fox.Tests.Common;

namespace Nagisa.Fox.Tests.Units.Lexing.Patterns
{
    [TestClass]
    public sealed class ContinuePatternTest
    {
        [TestMethod]
        public void TestIsMatch()
        {
            var file = string.Empty;
            var source = "continue";
            var pattern = new TextPattern("continue", TokenType.CONTINUE);

            var expectedResult = true;

            LexingTestHelper.AssertPatternIsMatch(pattern, file, source, expectedResult);
        }

        [TestMethod]
        public void TestRun()
        {
            var file = string.Empty;
            var source = "continue";
            var pattern = new TextPattern("continue", TokenType.CONTINUE);

            var position = new SourcePosition(0, 1, 1);
            var expectedToken = new Token(file, position, TokenType.CONTINUE, null);
            var expectedNext = new SourcePosition(8, 1, 9);

            LexingTestHelper.AssertPatternRun(pattern, file, source, expectedToken, expectedNext);
        }
    }
}