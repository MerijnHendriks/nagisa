namespace Lox.Compiler.Lexing.Patterns
{
    public sealed class AddAssignPattern : TextPattern
    {
        public AddAssignPattern() : base("+=", ETokenType.AddAssign)
        {
        }
    }
}