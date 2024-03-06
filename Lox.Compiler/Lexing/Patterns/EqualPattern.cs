namespace Lox.Compiler.Lexing.Patterns
{
    public class EqualPattern : TextPattern
    {
        public EqualPattern() : base("==", ETokenType.Equal)
        {
        }
    }
}