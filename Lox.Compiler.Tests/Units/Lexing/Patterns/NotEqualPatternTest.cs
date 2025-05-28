using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lox.Compiler.Lexing;
using Lox.Compiler.Lexing.Patterns;
using Lox.Compiler.Tests.Common;

namespace Lox.Compiler.Tests.Units.Lexing.Patterns
{
    [TestClass]
    public sealed class NotEqualPatternTest
    {
        [TestMethod]
        public void TestIsMatch()
        {
            var file = string.Empty;
            var source = "!=";
            var pattern = new TextPattern("!=", TokenType.NOT_EQUAL);

            var expectedResult = true;

            LexingTestHelper.AssertPatternIsMatch(pattern, file, source, expectedResult);
        }

        [TestMethod]
        public void TestRun()
        {
            var file = string.Empty;
            var source = "!=";
            var pattern = new TextPattern("!=", TokenType.NOT_EQUAL);

            var expectedToken = new Token(file, 0, TokenType.NOT_EQUAL, null);
            var expectedNext = new SourcePosition(file, 2, 1, 3);

            LexingTestHelper.AssertPatternRun(pattern, file, source, expectedToken, expectedNext);
        }
    }
}