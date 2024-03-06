namespace Lox.Compiler.Lexing.Patterns
{
    public class BitwiseOrPattern : CharacterPattern
    {
        public BitwiseOrPattern() : base('|', ETokenType.BitwiseOr)
        {
        }
    }
}