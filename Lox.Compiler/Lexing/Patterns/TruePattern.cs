namespace Lox.Compiler.Lexing.Patterns
{
    public sealed class TruePattern : TextPattern
    {
        public TruePattern() : base("true", TokenType.TRUE)
        {
        }
    }
}