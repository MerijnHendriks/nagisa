namespace Lox.Compiler.Lexing.Patterns
{
    public sealed class RightCirclePattern : CharacterPattern
    {
        public RightCirclePattern() : base(')', ETokenType.RightCircle)
        {
        }
    }
}