namespace Lox.Compiler.Lexing.Patterns
{
    public sealed class DivideAssignPattern : TextPattern
    {
        public DivideAssignPattern() : base("/=", TokenType.DIVIDE_ASSIGN)
        {
        }
    }
}