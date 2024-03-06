namespace Lox.Compiler.Lexing.Patterns
{
    public class LeftSquarePattern : CharacterPattern
    {
        public LeftSquarePattern() : base('[', ETokenType.LeftSquare)
        {
        }
    }
}