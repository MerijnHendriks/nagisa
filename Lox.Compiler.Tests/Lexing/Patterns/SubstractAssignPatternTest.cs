using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        public void TestSingle()
        {
            var file = string.Empty;
            var source = "-=";
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

        [TestMethod]
        public void TestSurrounded()
        {
            var file = string.Empty;
            var source = " -= ";
            var tokens = new Token[]
            {
                new Token(file, 0, TokenType.WHITESPACE, string.Empty),
                new Token(file, 1, TokenType.ADD_ASSIGN, string.Empty),
                new Token(file, 3, TokenType.WHITESPACE, string.Empty),
                new Token(file, 4, TokenType.END_OF_FILE, string.Empty)
            };
            var sourcemap = new SourcePosition[]
            {
                new SourcePosition(file, 0, 1, 1),
                new SourcePosition(file, 1, 1, 2),
                new SourcePosition(file, 3, 1, 4),
                new SourcePosition(file, 4, 1, 5)
            };

            _helper.AssertPattern(source, tokens, sourcemap);
        }
    }
} 