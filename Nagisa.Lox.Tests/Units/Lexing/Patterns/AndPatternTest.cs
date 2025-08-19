using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nagisa.Core.Lexing;
using Nagisa.Lox.Lexing;
using Nagisa.Lox.Tests.Common;

namespace Nagisa.Lox.Tests.Units.Lexing.Patterns
{
    [TestClass]
    public sealed class AndPatternTest
    {
        [TestMethod]
        public void TestIsMatch()
        {
            var file = string.Empty;
            var source = "and";
            var pattern = new TextPattern("and", TokenType.AND);

            var expectedResult = true;

            LexingTestHelper.AssertPatternIsMatch(pattern, file, source, expectedResult);
        }

        [TestMethod]
        public void TestRun()
        {
            var file = string.Empty;
            var source = "and";
            var pattern = new TextPattern("and", TokenType.AND);

            var position = new SourcePosition(0, 1, 1);
            var expectedToken = new Token(file, position, TokenType.AND, null);
            var expectedNext = new SourcePosition(3, 1, 4);

            LexingTestHelper.AssertPatternRun(pattern, file, source, expectedToken, expectedNext);
        }
    }
}