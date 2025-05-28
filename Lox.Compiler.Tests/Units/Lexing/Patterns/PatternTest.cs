using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lox.Compiler.Lexing;
using Lox.Compiler.Tests.Common;
using Lox.Compiler.Tests.Mocks.Lexing;

namespace Lox.Compiler.Tests.Units.Lexing.Patterns
{
    [TestClass]
    public sealed class PatternTest
    {
        [TestMethod]
        public void TestRun()
        {
            var file = string.Empty;
            var source = "a";
            var pattern = new PatternMock();

            var expectedToken = new Token(file, 0, TokenType.IDENTIFIER, null);
            var expectedNext = new SourcePosition(file, 1, 1, 2);

            LexingTestHelper.AssertPatternRun(pattern, file, source, expectedToken, expectedNext);
        }
    }
}