namespace Lox.Compiler.Lexing.Patterns
{
    public class RightCurlyPattern : CharacterPattern
    {
        public RightCurlyPattern() : base('}', ETokenType.RightCurly)
        {
        }
    }
}