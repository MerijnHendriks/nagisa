namespace Lox.Compiler.Lexing.Patterns
{
    public sealed class RightCurlyPattern : CharacterPattern
    {
        public RightCurlyPattern() : base('}', ETokenType.RightCurly)
        {
        }
    }
}