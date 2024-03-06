namespace Lox.Compiler.Lexing.Patterns
{
    public class BitwiseAndPattern : CharacterPattern
    {
        public BitwiseAndPattern() : base('&', ETokenType.BitwiseAnd)
        {
        }
    }
}