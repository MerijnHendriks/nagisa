namespace Lox.Compiler.Lexing.Patterns
{
    public sealed class BitwiseAndPattern : CharacterPattern
    {
        public BitwiseAndPattern() : base('&', TokenType.BITWISE_AND)
        {
        }
    }
}