namespace Lox.Compiler.Lexing.Patterns
{
    public class BreakPattern : TextPattern
    {
        public BreakPattern() : base("break", ETokenType.Break)
        {
        }
    }
}