using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nagisa.Fox.Lexing;
using Nagisa.Fox.Lexing.Patterns;
using Nagisa.Fox.Tests.Common;

namespace Nagisa.Fox.Tests.Units.Lexing.Patterns
{
    [TestClass]
    public sealed class DivideAssignPatternTest
    {
        [TestMethod]
        public void TestIsMatch()
        {
            var file = string.Empty;
            var source = "/=";
            var pattern = new TextPattern("/=", TokenType.DIVIDE_ASSIGN);

            var expectedResult = true;

            LexingTestHelper.AssertPatternIsMatch(pattern, file, source, expectedResult);
        }

        [TestMethod]
        public void TestRun()
        {
            var file = string.Empty;
            var source = "/=";
            var pattern = new TextPattern("/=", TokenType.DIVIDE_ASSIGN);

            var position = new SourcePosition(0, 1, 1);
            var expectedToken = new Token(file, position, TokenType.DIVIDE_ASSIGN, null);
            var expectedNext = new SourcePosition(2, 1, 3);

            LexingTestHelper.AssertPatternRun(pattern, file, source, expectedToken, expectedNext);
        }
    }
}