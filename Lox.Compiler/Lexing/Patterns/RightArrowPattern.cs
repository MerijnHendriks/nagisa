namespace Lox.Compiler.Lexing.Patterns
{
    public class RightArrowPattern : CharacterPattern
    {
        public RightArrowPattern() : base('>', ETokenType.RightArrow)
        {
        }
    }
}