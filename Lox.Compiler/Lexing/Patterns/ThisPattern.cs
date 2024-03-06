namespace Lox.Compiler.Lexing.Patterns
{
    public sealed class ThisPattern : TextPattern
    {
        public ThisPattern() : base("this", TokenType.THIS)
        {
        }
    }
}