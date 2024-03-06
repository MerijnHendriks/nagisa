namespace Lox.Compiler.Lexing.Patterns
{
    public sealed class ForPattern : TextPattern
    {
        public ForPattern() : base("for", TokenType.FOR)
        {
        }
    }
}