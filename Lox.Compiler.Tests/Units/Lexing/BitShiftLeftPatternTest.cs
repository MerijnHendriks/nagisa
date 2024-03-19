using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lox.Compiler.Lexing;
using Lox.Compiler.Lexing.Patterns;
using Lox.Compiler.Tests.Common;
using Lox.Compiler.Tests.Mocks.Lexing;

namespace Lox.Compiler.Tests.Units.Lexing.Patterns
{
    [TestClass]
    public sealed class BitShiftLeftPatternTest
    {
        [TestMethod]
        public void TestIsMatch()
        {
            var file = string.Empty;
            var source = "<<=";
            var pattern = new BitShiftLeftPattern();

            var truthResult = true;

            LexingTestHelper.AssertPatternIsMatch(pattern, file, source, truthResult);
        }

        [TestMethod]
        public void TestRun()
        {
            var file = string.Empty;
            var source = "<<=";
            var pattern = new BitShiftLeftPattern();

            var truthToken = new Token(file, 0, TokenType.BITSHIFT_LEFT, string.Empty);
            var truthNext = new SourcePosition(file, 3, 1, 4);

            LexingTestHelper.AssertPatternRun(pattern, file, source, truthToken, truthNext);
        }
    }
}