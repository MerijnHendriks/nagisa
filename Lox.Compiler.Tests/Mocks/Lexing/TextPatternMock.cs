using Lox.Compiler.Lexing;
using Lox.Compiler.Lexing.Patterns;

namespace Lox.Compiler.Tests.Mocks.Lexing
{
    public sealed class TextPatternMock : TextPattern
    {
        public TextPatternMock() : base("a", TokenType.IDENTIFIER)
        {
        }
    }
}