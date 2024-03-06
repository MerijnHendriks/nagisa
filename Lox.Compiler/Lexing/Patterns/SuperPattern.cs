namespace Lox.Compiler.Lexing.Patterns
{
    public class SuperPattern : TextPattern
    {
        public SuperPattern() : base("super", ETokenType.Super)
        {
        }
    }
}