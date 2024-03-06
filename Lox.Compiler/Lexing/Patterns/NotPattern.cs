namespace Lox.Compiler.Lexing.Patterns
{
    public sealed class NotPattern : CharacterPattern
    {
        public NotPattern() : base('!', ETokenType.Not)
        {
        }
    }
}