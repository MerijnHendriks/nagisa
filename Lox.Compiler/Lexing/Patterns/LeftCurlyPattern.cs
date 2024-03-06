namespace Lox.Compiler.Lexing.Patterns
{
    public sealed class LeftCurlyPattern : CharacterPattern
    {
        public LeftCurlyPattern() : base('{', ETokenType.LeftCurly)
        {
        }
    }
}