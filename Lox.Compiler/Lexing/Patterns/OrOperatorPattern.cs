namespace Lox.Compiler.Lexing.Patterns
{
    public class OrOperatorPattern : TextPattern
    {
        public OrOperatorPattern() : base("||", ETokenType.Or)
        {
        }
    }
}