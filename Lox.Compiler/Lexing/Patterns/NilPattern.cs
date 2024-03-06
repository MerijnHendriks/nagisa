namespace Lox.Compiler.Lexing.Patterns
{
    public sealed class NilPattern : TextPattern
    {
        public NilPattern() : base("nil", TokenType.NIL)
        {
        }
    }
}