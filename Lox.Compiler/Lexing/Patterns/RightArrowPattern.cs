namespace Lox.Compiler.Lexing.Patterns
{
    public sealed class RightArrowPattern : CharacterPattern
    {
        public RightArrowPattern() : base('>', ETokenType.RightArrow)
        {
        }
    }
}