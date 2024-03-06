namespace Lox.Compiler.Lexing.Patterns
{
    public class BitwiseComplementPattern : CharacterPattern
    {
        public BitwiseComplementPattern() : base('~', ETokenType.BitwiseComplement)
        {
        }
    }
}