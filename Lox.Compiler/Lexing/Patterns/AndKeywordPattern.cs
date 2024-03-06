namespace Lox.Compiler.Lexing.Patterns
{
    public sealed class AndKeywordPattern : TextPattern
    {
        public AndKeywordPattern() : base("and", ETokenType.And)
        {
        }
    }
}