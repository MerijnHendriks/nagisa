namespace Lox.Compiler.Lexing.Patterns
{
    public sealed class MinusPattern : CharacterPattern
    {
        public MinusPattern() : base('-', TokenType.MINUS)
        {
        }
    }
}