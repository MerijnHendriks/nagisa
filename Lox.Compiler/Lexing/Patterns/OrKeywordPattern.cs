namespace Lox.Compiler.Lexing.Patterns
{
    public sealed class OrKeywordPattern : TextPattern
    {
        public OrKeywordPattern() : base("or", ETokenType.Or)
        {
        }
    }
}