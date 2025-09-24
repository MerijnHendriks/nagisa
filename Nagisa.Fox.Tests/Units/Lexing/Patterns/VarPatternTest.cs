using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nagisa.Fox.Lexing;
using Nagisa.Fox.Lexing.Patterns;
using Nagisa.Fox.Tests.Common;

namespace Nagisa.Fox.Tests.Units.Lexing.Patterns
{
    [TestClass]
    public sealed class VarPatternTest
    {
        [TestMethod]
        public void TestIsMatch()
        {
            var file = string.Empty;
            var source = "var";
            var pattern = new TextPattern("var", TokenType.VAR);

            var expectedResult = true;

            LexingTestHelper.AssertPatternIsMatch(pattern, file, source, expectedResult);
        }

        [TestMethod]
        public void TestRun()
        {
            var file = string.Empty;
            var source = "var";
            var pattern = new TextPattern("var", TokenType.VAR);

            var position = new SourcePosition(0, 1, 1);
            var expectedToken = new Token(file, position, TokenType.VAR, null);
            var expectedNext = new SourcePosition(3, 1, 4);

            LexingTestHelper.AssertPatternRun(pattern, file, source, expectedToken, expectedNext);
        }
    }
}