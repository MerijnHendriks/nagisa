namespace Lox.Compiler.Lexing.Patterns
{
    public class IfPattern : TextPattern
    {
        public IfPattern() : base("if", ETokenType.If)
        {
        }
    }
}