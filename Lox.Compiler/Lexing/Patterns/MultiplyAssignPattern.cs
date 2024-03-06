namespace Lox.Compiler.Lexing.Patterns
{
    public class MultiplyAssignPattern : TextPattern
    {
        public MultiplyAssignPattern() : base("*=", ETokenType.MultiplyAssign)
        {
        }
    }
}