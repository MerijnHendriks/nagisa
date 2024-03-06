namespace Lox.Compiler.Lexing.Patterns
{
    public class BitShiftLeftPattern : TextPattern
    {
        public BitShiftLeftPattern() : base("<<=", ETokenType.BitShiftLeft)
        {
        }
    }
}