namespace Lox.Compiler.Lexing.Patterns
{
    public class SemicolonPattern : CharacterPattern
    {
        public SemicolonPattern() : base(';', ETokenType.Semicolon)
        {
        }
    }
}