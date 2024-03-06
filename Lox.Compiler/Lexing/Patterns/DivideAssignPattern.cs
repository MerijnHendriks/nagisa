namespace Lox.Compiler.Lexing.Patterns
{
    public class DivideAssignPattern : TextPattern
    {
        public DivideAssignPattern() : base("/=", ETokenType.DivideAssign)
        {
        }
    }
}