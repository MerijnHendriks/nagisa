namespace Lox.Compiler.Lexing.Patterns
{
    public sealed class ElsePattern : TextPattern
    {
        public ElsePattern() : base("else", TokenType.ELSE)
        {
        }
    }
}