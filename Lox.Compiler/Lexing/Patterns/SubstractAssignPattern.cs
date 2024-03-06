namespace Lox.Compiler.Lexing.Patterns
{
    public sealed class SubstractAssignPattern : TextPattern
    {
        public SubstractAssignPattern() : base("-=", TokenType.SUBSTRACT_ASSIGN)
        {
        }
    }
}