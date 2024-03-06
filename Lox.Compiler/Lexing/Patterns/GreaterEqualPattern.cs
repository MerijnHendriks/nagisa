namespace Lox.Compiler.Lexing.Patterns
{
    public sealed class GreaterEqualPattern : TextPattern
    {
        public GreaterEqualPattern() : base(">=", TokenType.GREATER_EQUAL)
        {
        }
    }
}