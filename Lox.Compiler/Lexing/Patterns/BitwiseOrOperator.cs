namespace Lox.Compiler.Lexing.Patterns
{
    public sealed class BitwiseOrPattern : CharacterPattern
    {
        public BitwiseOrPattern() : base('|', TokenType.BITWISE_OR)
        {
        }
    }
}