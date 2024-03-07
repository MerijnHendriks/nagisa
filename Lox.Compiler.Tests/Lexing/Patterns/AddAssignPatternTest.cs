using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lox.Compiler.Common;
using Lox.Compiler.Lexing;
using Lox.Compiler.Lexing.Patterns;
using Lox.Compiler.Tests.Common;

namespace Lox.Compiler.Tests.Lexing.Patterns
{
    [TestClass]
    public sealed class AddAssignPatternTest
    {
        private readonly Logger _logger;
        private readonly Scanner _scanner;

        public AddAssignPatternTest()
        {
            _logger = new TestLogger();
            _scanner = new Scanner(_logger);
        }

        [TestMethod]
        public void Test1()
        {
            // TODO: code here
            Assert.IsTrue(true);
        }
    }
}