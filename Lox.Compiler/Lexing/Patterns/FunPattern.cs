namespace Lox.Compiler.Lexing.Patterns
{
    public class FunPattern : TextPattern
    {
        public FunPattern() : base("fun", ETokenType.Function)
        {
        }
    }
}