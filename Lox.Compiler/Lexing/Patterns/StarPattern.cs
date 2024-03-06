namespace Lox.Compiler.Lexing.Patterns
{
    public sealed class StarPattern : CharacterPattern
    {
        public StarPattern() : base('*', TokenType.STAR)
        {
        }
    }
}