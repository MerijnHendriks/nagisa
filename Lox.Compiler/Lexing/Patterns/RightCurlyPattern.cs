namespace Lox.Compiler.Lexing.Patterns
{
    public sealed class RightCurlyPattern : CharacterPattern
    {
        public RightCurlyPattern() : base('}', TokenType.RIGHT_CURLY)
        {
        }
    }
}