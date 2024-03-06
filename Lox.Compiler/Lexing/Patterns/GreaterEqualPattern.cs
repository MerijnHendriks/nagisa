namespace Lox.Compiler.Lexing.Patterns
{
    public class GreaterEqualPattern : TextPattern
    {
        public GreaterEqualPattern() : base(">=", ETokenType.GreaterEqual)
        {
        }
    }
}