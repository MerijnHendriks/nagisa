namespace Lox.Compiler.Lexing.Patterns
{
    public sealed class CommaPattern : CharacterPattern
    {
        public CommaPattern() : base(',', TokenType.COMMA)
        {
        }
    }
}