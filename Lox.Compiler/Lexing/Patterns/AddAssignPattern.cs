namespace Lox.Compiler.Lexing.Patterns
{
    public class AddAssignPattern : TextPattern
    {
        public AddAssignPattern() : base("+=", ETokenType.AddAssign)
        {
        }
    }
}