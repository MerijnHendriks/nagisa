namespace Lox.Compiler.Lexing.Patterns
{
    public sealed class ClassPattern : TextPattern
    {
        public ClassPattern() : base("class", TokenType.CLASS)
        {
        }
    }
}