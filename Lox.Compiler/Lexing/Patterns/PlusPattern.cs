namespace Lox.Compiler.Lexing.Patterns
{
    public sealed class PlusPattern : CharacterPattern
    {
        public PlusPattern() : base('+', ETokenType.Plus)
        {
        }
    }
}