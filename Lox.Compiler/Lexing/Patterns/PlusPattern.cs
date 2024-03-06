namespace Lox.Compiler.Lexing.Patterns
{
    public class PlusPattern : CharacterPattern
    {
        public PlusPattern() : base('+', ETokenType.Plus)
        {
        }
    }
}