namespace Lox.Compiler.Lexing.Patterns
{
    public class NotPattern : CharacterPattern
    {
        public NotPattern() : base('!', ETokenType.Not)
        {
        }
    }
}