namespace Lox.Compiler.Lexing.Patterns
{
    public sealed class BitwiseComplementPattern : CharacterPattern
    {
        public BitwiseComplementPattern() : base('~', ETokenType.BitwiseComplement)
        {
        }
    }
}