namespace Lox.Compiler.Lexing.Patterns
{
    public sealed class WhitespacePattern : CharacterPattern
    {
        public WhitespacePattern() : base(' ', TokenType.WHITESPACE)
        {
        }
    }
}