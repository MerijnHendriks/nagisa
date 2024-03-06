namespace Lox.Compiler.Lexing.Patterns
{
    public class WhilePattern : TextPattern
    {
        public WhilePattern() : base("while", ETokenType.While)
        {
        }
    }
}