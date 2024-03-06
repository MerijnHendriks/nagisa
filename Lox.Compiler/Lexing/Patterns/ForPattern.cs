namespace Lox.Compiler.Lexing.Patterns
{
    public class ForPattern : TextPattern
    {
        public ForPattern() : base("for", ETokenType.For)
        {
        }
    }
}