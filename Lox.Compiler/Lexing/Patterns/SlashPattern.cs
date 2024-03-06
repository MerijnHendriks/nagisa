namespace Lox.Compiler.Lexing.Patterns
{
    public class SlashPattern : CharacterPattern
    {
        public SlashPattern() : base('/', ETokenType.Slash)
        {
        }
    }
}