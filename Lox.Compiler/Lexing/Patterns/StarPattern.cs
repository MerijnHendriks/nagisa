namespace Lox.Compiler.Lexing.Patterns
{
    public class StarPattern : CharacterPattern
    {
        public StarPattern() : base('*', ETokenType.Star)
        {
        }
    }
}