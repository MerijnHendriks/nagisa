using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lox.Compiler.Lexing;
using Lox.Compiler.Language.Lexing;
using Lox.Compiler.Tests.Common;

namespace Lox.Compiler.Tests.Units.Lexing.Patterns
{
    [TestClass]
    public sealed class LeftCirclePatternTest
    {
        [TestMethod]
        public void TestIsMatch()
        {
            var file = string.Empty;
            var source = "(";
            var pattern = new CharacterPattern('(', TokenType.LEFT_CIRCLE);

            var expectedResult = true;

            LexingTestHelper.AssertPatternIsMatch(pattern, file, source, expectedResult);
        }

        [TestMethod]
        public void TestRun()
        {
            var file = string.Empty;
            var source = "(";
            var pattern = new CharacterPattern('(', TokenType.LEFT_CIRCLE);

            var expectedToken = new Token(file, 0, TokenType.LEFT_CIRCLE, null);
            var expectedNext = new SourcePosition(file, 1, 1, 2);

            LexingTestHelper.AssertPatternRun(pattern, file, source, expectedToken, expectedNext);
        }
    }
}