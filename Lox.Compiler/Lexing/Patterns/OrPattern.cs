namespace Lox.Compiler.Lexing.Patterns
{
    public sealed class OrPattern : TextPattern
    {
        public OrPattern() : base("or", TokenType.OR)
        {
        }
    }
}