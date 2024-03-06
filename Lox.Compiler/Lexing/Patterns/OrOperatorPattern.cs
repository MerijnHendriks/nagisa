namespace Lox.Compiler.Lexing.Patterns
{
    public sealed class OrOperatorPattern : TextPattern
    {
        public OrOperatorPattern() : base("||", TokenType.OR)
        {
        }
    }
}