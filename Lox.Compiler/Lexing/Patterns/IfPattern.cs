namespace Lox.Compiler.Lexing.Patterns
{
    public sealed class IfPattern : TextPattern
    {
        public IfPattern() : base("if", TokenType.IF)
        {
        }
    }
}