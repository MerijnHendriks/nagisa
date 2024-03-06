namespace Lox.Compiler.Lexing.Patterns
{
    public sealed class TabPattern : TextPattern
    {
        public TabPattern() : base("\t", ETokenType.Tab)
        {
        }
    }
}