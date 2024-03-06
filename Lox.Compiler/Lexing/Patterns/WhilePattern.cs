namespace Lox.Compiler.Lexing.Patterns
{
    public sealed class WhilePattern : TextPattern
    {
        public WhilePattern() : base("while", TokenType.WHILE)
        {
        }
    }
}