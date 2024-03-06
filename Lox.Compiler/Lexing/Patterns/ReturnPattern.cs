namespace Lox.Compiler.Lexing.Patterns
{
    public class ReturnPattern : TextPattern
    {
        public ReturnPattern() : base("return", ETokenType.Return)
        {
        }
    }
}