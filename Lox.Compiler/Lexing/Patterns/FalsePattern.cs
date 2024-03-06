namespace Lox.Compiler.Lexing.Patterns
{
    public sealed class FalsePattern : TextPattern
    {
        public FalsePattern() : base("false", TokenType.FALSE)
        {
        }
    }
}