namespace Lox.Compiler.Lexing.Patterns
{
    public sealed class BreakPattern : TextPattern
    {
        public BreakPattern() : base("break", ETokenType.Break)
        {
        }
    }
}