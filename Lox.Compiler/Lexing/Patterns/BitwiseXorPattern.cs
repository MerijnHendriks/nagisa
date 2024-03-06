namespace Lox.Compiler.Lexing.Patterns
{
    public class BitwiseXorPattern : CharacterPattern
    {
        public BitwiseXorPattern() : base('^', ETokenType.BitwiseXor)
        {
        }
    }
}