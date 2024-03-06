namespace Lox.Compiler.Lexing.Patterns
{
    public class TruePattern : TextPattern
    {
        public TruePattern() : base("true", ETokenType.True)
        {
        }
    }
}