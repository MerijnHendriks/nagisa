using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lox.Compiler.Lexing;
using Lox.Compiler.Lexing.Patterns;
using Lox.Compiler.Tests.Common;

namespace Lox.Compiler.Tests.Units.Lexing.Patterns
{
    [TestClass]
    public sealed class IfPatternTest
    {
        [TestMethod]
        public void TestIsMatch()
        {
            var file = string.Empty;
            var source = "if";
            var pattern = new TextPattern("if", TokenType.IF);

            var expectedResult = true;

            LexingTestHelper.AssertPatternIsMatch(pattern, file, source, expectedResult);
        }

        [TestMethod]
        public void TestRun()
        {
            var file = string.Empty;
            var source = "if";
            var pattern = new TextPattern("if", TokenType.IF);

            var expectedToken = new Token(file, 0, TokenType.IF, string.Empty);
            var expectedNext = new SourcePosition(file, 2, 1, 3);

            LexingTestHelper.AssertPatternRun(pattern, file, source, expectedToken, expectedNext);
        }
    }
}