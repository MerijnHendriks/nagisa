namespace Lox.Compiler.Lexing.Patterns
{
    public class NilPattern : TextPattern
    {
        public NilPattern() : base("nil", ETokenType.Nil)
        {
        }
    }
}