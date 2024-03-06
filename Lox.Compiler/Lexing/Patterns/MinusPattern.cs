namespace Lox.Compiler.Lexing.Patterns
{
    public class MinusPattern : CharacterPattern
    {
        public MinusPattern() : base('-', ETokenType.Minus)
        {
        }
    }
}