namespace Lox.Compiler.Lexing.Patterns
{
    public sealed class ContinuePattern : TextPattern
    {
        public ContinuePattern() : base("continue", TokenType.CONTINUE)
        {
        }
    }
}