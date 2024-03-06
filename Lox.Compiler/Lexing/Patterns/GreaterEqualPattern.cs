namespace Lox.Compiler.Lexing.Patterns
{
    public sealed class GreaterEqualPattern : TextPattern
    {
        public GreaterEqualPattern() : base(">=", ETokenType.GreaterEqual)
        {
        }
    }
}