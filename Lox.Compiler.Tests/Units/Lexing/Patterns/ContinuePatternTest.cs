using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lox.Compiler.Lexing;
using Lox.Compiler.Language.Lexing;
using Lox.Compiler.Tests.Common;

namespace Lox.Compiler.Tests.Units.Lexing.Patterns
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

            var expectedToken = new Token(file, 0, TokenType.CONTINUE, null);
            var expectedNext = new SourcePosition(file, 8, 1, 9);

            LexingTestHelper.AssertPatternRun(pattern, file, source, expectedToken, expectedNext);
        }
    }
}