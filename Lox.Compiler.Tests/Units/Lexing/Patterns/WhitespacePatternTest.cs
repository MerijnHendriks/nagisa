using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lox.Compiler.Lexing;
using Lox.Compiler.Language.Lexing;
using Lox.Compiler.Tests.Common;

namespace Lox.Compiler.Tests.Units.Lexing.Patterns
{
    [TestClass]
    public sealed class WhitespacePatternTest
    {
        [TestMethod]
        public void TestIsMatch()
        {
            var file = string.Empty;
            var source = " ";
            var pattern = new CharacterPattern(' ', TokenType.WHITESPACE);

            var expectedResult = true;

            LexingTestHelper.AssertPatternIsMatch(pattern, file, source, expectedResult);
        }

        [TestMethod]
        public void TestRun()
        {
            var file = string.Empty;
            var source = " ";
            var pattern = new CharacterPattern(' ', TokenType.WHITESPACE);

            var expectedToken = new Token(file, 0, TokenType.WHITESPACE, null);
            var expectedNext = new SourcePosition(file, 1, 1, 2);

            LexingTestHelper.AssertPatternRun(pattern, file, source, expectedToken, expectedNext);
        }
    }
}