namespace Lox.Compiler.Lexing.Patterns
{
    public class LeftArrowPattern : CharacterPattern
    {
        public LeftArrowPattern() : base('<', ETokenType.LeftArrow)
        {
        }
    }
}