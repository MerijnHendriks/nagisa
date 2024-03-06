namespace Lox.Compiler.Lexing.Patterns
{
    public class LessEqualPattern : TextPattern
    {
        public LessEqualPattern() : base("<=", ETokenType.LessEqual)
        {
        }
    }
}