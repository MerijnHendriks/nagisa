namespace Lox.Compiler.Lexing.Patterns
{
    public class ElsePattern : TextPattern
    {
        public ElsePattern() : base("else", ETokenType.Else)
        {
        }
    }
}