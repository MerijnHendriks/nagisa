namespace Lox.Compiler.Lexing.Patterns
{
    public sealed class SemicolonPattern : CharacterPattern
    {
        public SemicolonPattern() : base(';', TokenType.SEMICOLON)
        {
        }
    }
}