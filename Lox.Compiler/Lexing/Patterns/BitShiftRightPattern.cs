namespace Lox.Compiler.Lexing.Patterns
{
    public class BitShiftRightPattern : TextPattern
    {
        public BitShiftRightPattern() : base(">>=", ETokenType.BitShiftRight)
        {
        }
    }
}