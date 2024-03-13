using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lox.Compiler.Lexing;
using Lox.Compiler.Lexing.Patterns;
using Lox.Compiler.Tests.Common;
using Lox.Compiler.Tests.Mocks.Lexing;

namespace Lox.Compiler.Tests.Integration.Lexing.Patterns
{
    [TestClass]
    public sealed class CharacterPatternTest
    {
        private readonly LexingTestHelper _helper;

        public CharacterPatternTest()
        {
            _helper = new LexingTestHelper();
        }

        [TestMethod]
        public void TestIsMatch()
        {
            var file = string.Empty;
            var source = "a";
            var current = new SourcePosition(file, 0, 1, 1);
            var pattern = new CharacterPatternMock();

            var truthResult = true;

            _helper.AssertPatternIsMatch(pattern, source, current, truthResult);
        }

        [TestMethod]
        public void TestRun()
        {
            var file = string.Empty;
            var source = "a";
            var current = new SourcePosition(file, 0, 1, 1);
            var pattern = new CharacterPatternMock();

            var truthToken = new Token(file, 0, TokenType.IDENTIFIER, string.Empty);
            var truthNext = new SourcePosition(file, 1, 1, 2);

            _helper.AssertPatternRun(pattern, file, source, current, truthToken, truthNext);
        }
    }
}