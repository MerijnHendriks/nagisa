namespace Lox.Compiler.Lexing.Patterns
{
    public sealed class LeftCirclePattern : CharacterPattern
    {
        public LeftCirclePattern() : base('(', TokenType.LEFT_CIRCLE)
        {
        }
    }
}