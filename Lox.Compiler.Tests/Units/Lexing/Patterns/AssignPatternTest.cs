using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lox.Compiler.Lexing;
using Lox.Compiler.Lexing.Patterns;
using Lox.Compiler.Tests.Common;

namespace Lox.Compiler.Tests.Units.Lexing.Patterns
{
    [TestClass]
    public sealed class AssignPatternTest
    {
        [TestMethod]
        public void TestIsMatch()
        {
            var file = string.Empty;
            var source = "=";
            var pattern = new CharacterPattern('=', TokenType.ASSIGN);

            var expectedResult = true;

            LexingTestHelper.AssertPatternIsMatch(pattern, file, source, expectedResult);
        }

        [TestMethod]
        public void TestRun()
        {
            var file = string.Empty;
            var source = "=";
            var pattern = new CharacterPattern('=', TokenType.ASSIGN);

            var expectedToken = new Token(file, 0, TokenType.ASSIGN, string.Empty);
            var expectedNext = new SourcePosition(file, 1, 1, 2);

            LexingTestHelper.AssertPatternRun(pattern, file, source, expectedToken, expectedNext);
        }
    }
}