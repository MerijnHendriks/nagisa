namespace Lox.Compiler.Lexing.Patterns
{
    public sealed class ReturnPattern : TextPattern
    {
        public ReturnPattern() : base("return", ETokenType.Return)
        {
        }
    }
}