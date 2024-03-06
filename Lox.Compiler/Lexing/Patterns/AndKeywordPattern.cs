namespace Lox.Compiler.Lexing.Patterns
{
    public class AndKeywordPattern : TextPattern
    {
        public AndKeywordPattern() : base("and", ETokenType.And)
        {
        }
    }
}