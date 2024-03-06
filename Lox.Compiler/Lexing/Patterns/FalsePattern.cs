namespace Lox.Compiler.Lexing.Patterns
{
    public class FalsePattern : TextPattern
    {
        public FalsePattern() : base("false", ETokenType.False)
        {
        }
    }
}