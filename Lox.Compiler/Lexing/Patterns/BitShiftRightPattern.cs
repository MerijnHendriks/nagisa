namespace Lox.Compiler.Lexing.Patterns
{
    public sealed class BitShiftRightPattern : TextPattern
    {
        public BitShiftRightPattern() : base(">>=", TokenType.BITSHIFT_RIGHT)
        {
        }
    }
}