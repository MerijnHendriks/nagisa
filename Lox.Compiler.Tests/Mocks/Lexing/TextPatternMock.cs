using Lox.Compiler.Lexing.Patterns;

namespace Lox.Compiler.Tests.Mocks.Lexing
{
    public sealed class TextPatternMock : TextPattern
    {
        public TextPatternMock(string target, int type) : base(target, type)
        {
        }
    }
}