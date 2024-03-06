namespace Lox.Compiler.Lexing.Patterns
{
    public sealed class RightCirclePattern : CharacterPattern
    {
        public RightCirclePattern() : base(')', TokenType.RIGHT_CIRCLE)
        {
        }
    }
}