using Lox.Compiler.Lexing.Patterns;

namespace Lox.Compiler.Tests.Mocks.Lexing
{
    public sealed class CharacterPatternMock : CharacterPattern
    {
        public CharacterPatternMock(char target, int type) : base(target, type)
        {
        }
    }
}