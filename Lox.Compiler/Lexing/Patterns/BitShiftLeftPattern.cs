namespace Lox.Compiler.Lexing.Patterns
{
    public sealed class BitShiftLeftPattern : TextPattern
    {
        public BitShiftLeftPattern() : base("<<=", TokenType.BITSHIFT_LEFT)
        {
        }
    }
}