namespace Lox.Compiler.Lexing.Patterns
{
    public sealed class DotPattern : CharacterPattern
    {
        public DotPattern() : base('.', ETokenType.Dot)
        {
        }
    }
}