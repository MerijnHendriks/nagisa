namespace Lox.Compiler.Lexing.Patterns
{
    public sealed class NotEqualPattern : TextPattern
    {
        public NotEqualPattern() : base("!=", TokenType.NOT_EQUAL)
        {
        }
    }
}