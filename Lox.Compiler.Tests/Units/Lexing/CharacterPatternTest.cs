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
            // intepreter
            var file = string.Empty;
            var source = "a";

            // scanner
            var current = new SourcePosition(file, 0, 1, 1);

            // pattern
            var pattern = new CharacterPatternMock('a', TokenType.IDENTIFIER);
            var result = pattern.IsMatch(source, current);

            // validate
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestRun()
        {
            // truths
            var truthToken = new Token(string.Empty, 0, TokenType.IDENTIFIER, string.Empty);
            var truthSourcePosition = new SourcePosition(string.Empty, 1, 1, 2);

            // intepreter
            var file = string.Empty;
            var source = "a";

            // scanner
            var current = new SourcePosition(file, 0, 1, 1);
            var token = new Token();

            // pattern
            var pattern = new CharacterPatternMock('a', TokenType.IDENTIFIER);
            var next = pattern.Run(file, source, current, ref token);

            // validate
            _helper.AssertToken(truthToken, token);
            _helper.AssertSourcePosition(truthSourcePosition, next);
        }
    }
}