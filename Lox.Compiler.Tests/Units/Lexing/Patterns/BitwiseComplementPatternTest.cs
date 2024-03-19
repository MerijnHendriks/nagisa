using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lox.Compiler.Lexing;
using Lox.Compiler.Lexing.Patterns;
using Lox.Compiler.Tests.Common;
using Lox.Compiler.Tests.Mocks.Lexing;

namespace Lox.Compiler.Tests.Units.Lexing.Patterns
{
    [TestClass]
    public sealed class BitwiseComplementPatternTest
    {
        [TestMethod]
        public void TestIsMatch()
        {
            var file = string.Empty;
            var source = "~";
            var pattern = new BitwiseComplementPattern();

            var truthResult = true;

            LexingTestHelper.AssertPatternIsMatch(pattern, file, source, truthResult);
        }

        [TestMethod]
        public void TestRun()
        {
            var file = string.Empty;
            var source = "~";
            var pattern = new BitwiseComplementPattern();

            var truthToken = new Token(file, 0, TokenType.BITWISE_COMPLEMENT, string.Empty);
            var truthNext = new SourcePosition(file, 1, 1, 2);

            LexingTestHelper.AssertPatternRun(pattern, file, source, truthToken, truthNext);
        }
    }
}