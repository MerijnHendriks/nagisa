namespace Lox.Compiler.Lexing.Patterns
{
    public class AndOperatorPattern : TextPattern
    {
        public AndOperatorPattern() : base("&&", ETokenType.And)
        {
        }
    }
}