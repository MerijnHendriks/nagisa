namespace Lox.Compiler.Lexing.Patterns
{
    public class NotEqualPattern : TextPattern
    {
        public NotEqualPattern() : base("!=", ETokenType.NotEqual)
        {
        }
    }
}