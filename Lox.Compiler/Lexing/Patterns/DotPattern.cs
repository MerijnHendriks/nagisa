namespace Lox.Compiler.Lexing.Patterns
{
    public class DotPattern : CharacterPattern
    {
        public DotPattern() : base('.', ETokenType.Dot)
        {
        }
    }
}