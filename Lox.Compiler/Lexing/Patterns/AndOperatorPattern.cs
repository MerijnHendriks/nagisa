namespace Lox.Compiler.Lexing.Patterns
{
    public sealed class AndOperatorPattern : TextPattern
    {
        public AndOperatorPattern() : base("&&", TokenType.AND)
        {
        }
    }
}