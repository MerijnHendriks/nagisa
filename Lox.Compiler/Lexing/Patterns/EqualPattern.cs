namespace Lox.Compiler.Lexing.Patterns
{
    public sealed class EqualPattern : TextPattern
    {
        public EqualPattern() : base("==", ETokenType.Equal)
        {
        }
    }
}