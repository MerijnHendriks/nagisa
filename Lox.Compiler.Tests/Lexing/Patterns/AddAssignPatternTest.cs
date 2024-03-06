using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lox.Compiler.Lexing;
using Lox.Compiler.Lexing.Patterns;

namespace Lox.Compiler.Tests.Lexing.Patterns
{
    [TestClass]
    public class AddAssignPatternTest
    {
        [TestMethod]
        public void Test1()
        {
            var logger = new Logger();
            var scanner = new Scanner(logger);

            // TODO: code here

            Assert.IsTrue(true);
        }
    }
}