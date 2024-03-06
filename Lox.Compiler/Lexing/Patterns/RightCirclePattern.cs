namespace Lox.Compiler.Lexing.Patterns
{
    public class RightCirclePattern : CharacterPattern
    {
        public RightCirclePattern() : base(')', ETokenType.RightCircle)
        {
        }
    }
}