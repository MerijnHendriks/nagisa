namespace Lox.Compiler.Lexing.Patterns
{
    public sealed class LeftSquarePattern : CharacterPattern
    {
        public LeftSquarePattern() : base('[', ETokenType.LeftSquare)
        {
        }
    }
}