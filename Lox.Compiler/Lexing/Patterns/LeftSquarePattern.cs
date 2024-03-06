namespace Lox.Compiler.Lexing.Patterns
{
    public sealed class LeftSquarePattern : CharacterPattern
    {
        public LeftSquarePattern() : base('[', TokenType.LEFT_SQUARE)
        {
        }
    }
}