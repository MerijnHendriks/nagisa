namespace Lox.Compiler.Lexing.Patterns
{
    public class LeftCirclePattern : CharacterPattern
    {
        public LeftCirclePattern() : base('(', ETokenType.LeftCircle)
        {
        }
    }
}