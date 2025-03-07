using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lox.Compiler.Lexing;
using Lox.Compiler.Lexing.Patterns;
using Lox.Compiler.Tests.Common;

namespace Lox.Compiler.Tests.Units.Lexing.Patterns
{
    [TestClass]
    public sealed class NilPatternTest
    {
        [TestMethod]
        public void TestIsMatch()
        {
            var file = string.Empty;
            var source = "nil";
            var pattern = new TextPattern("nil", TokenType.NIL);

            var expectedResult = true;

            LexingTestHelper.AssertPatternIsMatch(pattern, file, source, expectedResult);
        }

        [TestMethod]
        public void TestRun()
        {
            var file = string.Empty;
            var source = "nil";
            var pattern = new TextPattern("nil", TokenType.NIL);

            var expectedToken = new Token(file, 0, TokenType.NIL, string.Empty);
            var expectedNext = new SourcePosition(file, 3, 1, 4);

            LexingTestHelper.AssertPatternRun(pattern, file, source, expectedToken, expectedNext);
        }
    }
}