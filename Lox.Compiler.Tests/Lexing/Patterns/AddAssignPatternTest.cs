using System.Collections.Generic;
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
        private readonly PatternTestHelper _helper;

        public AddAssignPatternTest()
        {
            _helper = new PatternTestHelper();
        }

        [TestMethod]
        public void Test1()
        {
            var file = string.Empty;
            var source = "+=";
            var tokens = new Token[]
            {
                new Token(file, 0, TokenType.ADD_ASSIGN, string.Empty),
                new Token(file, 2, TokenType.END_OF_FILE, string.Empty)
            };
            var sourcemap = new SourcePosition[]
            {
                new SourcePosition(file, 0, 1, 1),
                new SourcePosition(file, 2, 1, 3)
            };

            _helper.AssertPattern(source, tokens, sourcemap);
        }
    }
}