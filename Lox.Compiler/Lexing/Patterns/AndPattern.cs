namespace Lox.Compiler.Lexing.Patterns
{
    public sealed class AndPattern : TextPattern
    {
        public AndPattern() : base("and", TokenType.AND)
        {
        }
    }
}