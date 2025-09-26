using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nagisa.Fox.Lexing;
using Nagisa.Fox.Tests.Common;

namespace Nagisa.Fox.Tests.Units.Lexing.Patterns
{
    [TestClass]
    public sealed class TruePatternTest
    {
        [TestMethod]
        public void TestIsMatch()
        {
            var file = string.Empty;
            var source = "true";
            var pattern = new TextPattern("true", TokenType.TRUE);

            var expectedResult = true;

            LexingTestHelper.AssertPatternIsMatch(pattern, file, source, expectedResult);
        }

        [TestMethod]
        public void TestRun()
        {
            var file = string.Empty;
            var source = "true";
            var pattern = new TextPattern("true", TokenType.TRUE);

            var position = new SourcePosition(0, 1, 1);
            var expectedToken = new Token(file, position, TokenType.TRUE, null);
            var expectedNext = new SourcePosition(4, 1, 5);

            LexingTestHelper.AssertPatternRun(pattern, file, source, expectedToken, expectedNext);
        }
    }
}