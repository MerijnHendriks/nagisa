using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lox.Compiler.Lexing;
using Lox.Compiler.Lexing.Patterns;
using Lox.Compiler.Tests.Common;

namespace Lox.Compiler.Tests.Units.Lexing.Patterns
{
    [TestClass]
    public sealed class AddAssignPatternTest
    {
        [TestMethod]
        public void TestIsMatch()
        {
            var file = string.Empty;
            var source = "+=";
            var pattern = new TextPattern("+=", TokenType.ADD_ASSIGN);

            var expectedResult = true;

            LexingTestHelper.AssertPatternIsMatch(pattern, file, source, expectedResult);
        }

        [TestMethod]
        public void TestRun()
        {
            var file = string.Empty;
            var source = "+=";
            var pattern = new TextPattern("+=", TokenType.ADD_ASSIGN);

            var expectedToken = new Token(file, 0, TokenType.ADD_ASSIGN, string.Empty);
            var expectedNext = new SourcePosition(file, 2, 1, 3);

            LexingTestHelper.AssertPatternRun(pattern, file, source, expectedToken, expectedNext);
        }
    }
}