namespace Lox.Compiler.Lexing.Patterns
{
    public sealed class BitwiseXorPattern : CharacterPattern
    {
        public BitwiseXorPattern() : base('^', ETokenType.BitwiseXor)
        {
        }
    }
}