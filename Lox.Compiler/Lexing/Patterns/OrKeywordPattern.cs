namespace Lox.Compiler.Lexing.Patterns
{
    public class OrKeywordPattern : TextPattern
    {
        public OrKeywordPattern() : base("or", ETokenType.Or)
        {
        }
    }
}