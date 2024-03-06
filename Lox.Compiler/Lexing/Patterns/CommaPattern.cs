namespace Lox.Compiler.Lexing.Patterns
{
    public class CommaPattern : CharacterPattern
    {
        public CommaPattern() : base(',', ETokenType.Comma)
        {
        }
    }
}