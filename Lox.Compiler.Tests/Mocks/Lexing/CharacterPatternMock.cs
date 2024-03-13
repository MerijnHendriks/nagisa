using Lox.Compiler.Lexing;
using Lox.Compiler.Lexing.Patterns;

namespace Lox.Compiler.Tests.Mocks.Lexing
{
    public sealed class CharacterPatternMock : CharacterPattern
    {
        public CharacterPatternMock() : base('a', TokenType.IDENTIFIER)
        {
        }
    }
}