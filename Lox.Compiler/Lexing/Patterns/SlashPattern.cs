namespace Lox.Compiler.Lexing.Patterns
{
    public sealed class SlashPattern : CharacterPattern
    {
        public SlashPattern() : base('/', TokenType.SLASH)
        {
        }
    }
}