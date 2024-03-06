namespace Lox.Compiler.Lexing.Patterns
{
    public class TabPattern : TextPattern
    {
        public TabPattern() : base("\t", ETokenType.Tab)
        {
        }
    }
}