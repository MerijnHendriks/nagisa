namespace Lox.Compiler.Lexing.Patterns
{
    public sealed class MultiplyAssignPattern : TextPattern
    {
        public MultiplyAssignPattern() : base("*=", ETokenType.MultiplyAssign)
        {
        }
    }
}