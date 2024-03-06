namespace Lox.Compiler.Lexing.Patterns
{
    public sealed class RightSquarePattern : CharacterPattern
    {
        public RightSquarePattern() : base(']', ETokenType.RightSquare)
        {
        }
    }
}