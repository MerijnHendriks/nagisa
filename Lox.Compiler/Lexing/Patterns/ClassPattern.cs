namespace Lox.Compiler.Lexing.Patterns
{
    public class ClassPattern : TextPattern
    {
        public ClassPattern() : base("class", ETokenType.Class)
        {
        }
    }
}