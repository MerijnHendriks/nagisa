namespace Lox.Compiler.Lexing.Patterns
{
    public sealed class SuperPattern : TextPattern
    {
        public SuperPattern() : base("super", ETokenType.Super)
        {
        }
    }
}