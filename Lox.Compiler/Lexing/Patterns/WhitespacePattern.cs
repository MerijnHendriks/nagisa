namespace Lox.Compiler.Lexing.Patterns
{
    public class WhitespacePattern : CharacterPattern
    {
        public WhitespacePattern() : base(' ', ETokenType.Whitespace)
        {
        }
    }
}