namespace Lox.Compiler.Lexing.Patterns
{
    public sealed class SubstractAssignPattern : TextPattern
    {
        public SubstractAssignPattern() : base("-=", ETokenType.SubstractAssign)
        {
        }
    }
}