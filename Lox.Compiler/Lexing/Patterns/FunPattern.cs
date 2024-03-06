namespace Lox.Compiler.Lexing.Patterns
{
    public sealed class FunPattern : TextPattern
    {
        public FunPattern() : base("fun", ETokenType.Function)
        {
        }
    }
}