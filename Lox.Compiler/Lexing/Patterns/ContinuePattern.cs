namespace Lox.Compiler.Lexing.Patterns
{
    public class ContinuePattern : TextPattern
    {
        public ContinuePattern() : base("continue", ETokenType.Continue)
        {
        }
    }
}