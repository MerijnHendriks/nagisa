namespace Lox.Compiler.Lexing.Patterns
{
    public sealed class LeftArrowPattern : CharacterPattern
    {
        public LeftArrowPattern() : base('<', TokenType.LEFT_ARROW)
        {
        }
    }
}