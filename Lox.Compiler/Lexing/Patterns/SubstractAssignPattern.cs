namespace Lox.Compiler.Lexing.Patterns
{
    public class SubstractAssignPattern : TextPattern
    {
        public SubstractAssignPattern() : base("-=", ETokenType.SubstractAssign)
        {
        }
    }
}