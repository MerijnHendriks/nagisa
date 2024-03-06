namespace Lox.Compiler.Lexing.Patterns
{
    public sealed class LessEqualPattern : TextPattern
    {
        public LessEqualPattern() : base("<=", ETokenType.LessEqual)
        {
        }
    }
}