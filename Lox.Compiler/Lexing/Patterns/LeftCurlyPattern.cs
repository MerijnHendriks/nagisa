namespace Lox.Compiler.Lexing.Patterns
{
    public class LeftCurlyPattern : CharacterPattern
    {
        public LeftCurlyPattern() : base('{', ETokenType.LeftCurly)
        {
        }
    }
}