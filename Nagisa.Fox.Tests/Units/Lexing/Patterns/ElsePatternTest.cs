using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nagisa.Fox.Lexing;
using Nagisa.Fox.Lexing.Patterns;
using Nagisa.Fox.Tests.Common;

namespace Nagisa.Fox.Tests.Units.Lexing.Patterns
{
    [TestClass]
    public sealed class ElsePatternTest
    {
        [TestMethod]
        public void TestIsMatch()
        {
            var file = string.Empty;
            var source = "else";
            var pattern = new TextPattern("else", TokenType.ELSE);

            var expectedResult = true;

            LexingTestHelper.AssertPatternIsMatch(pattern, file, source, expectedResult);
        }

        [TestMethod]
        public void TestRun()
        {
            var file = string.Empty;
            var source = "else";
            var pattern = new TextPattern("else", TokenType.ELSE);

            var position = new SourcePosition(0, 1, 1);
            var expectedToken = new Token(file, position, TokenType.ELSE, null);
            var expectedNext = new SourcePosition(4, 1, 5);

            LexingTestHelper.AssertPatternRun(pattern, file, source, expectedToken, expectedNext);
        }
    }
}