using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lox.Compiler.Lexing;
using Lox.Compiler.Lexing.Patterns;
using Lox.Compiler.Tests.Common;
using Lox.Compiler.Tests.Mocks.Lexing;

namespace Lox.Compiler.Tests.Units.Lexing.Patterns
{
    [TestClass]
    public sealed class AddAssignPatternTest
    {
        private readonly LexingTestHelper _helper;

        public AddAssignPatternTest()
        {
            _helper = new LexingTestHelper();
        }

        [TestMethod]
        public void TestIsMatch()
        {
            var file = string.Empty;
            var source = "+=";
            var pattern = new AddAssignPattern();

            var truthResult = true;

            _helper.AssertPatternIsMatch(pattern, file, source, truthResult);
        }

        [TestMethod]
        public void TestRun()
        {
            var file = string.Empty;
            var source = "+=";
            var pattern = new AddAssignPattern();

            var truthToken = new Token(file, 0, TokenType.ADD_ASSIGN, string.Empty);
            var truthNext = new SourcePosition(file, 2, 1, 3);

            _helper.AssertPatternRun(pattern, file, source, truthToken, truthNext);
        }
    }
}