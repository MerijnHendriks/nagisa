namespace Lox.Compiler.Lexing.Patterns
{
    public class RightSquarePattern : CharacterPattern
    {
        public RightSquarePattern() : base(']', ETokenType.RightSquare)
        {
        }
    }
}