namespace Lox.Compiler.Lexing.Patterns
{
    public class AssignPattern : CharacterPattern
    {
        public AssignPattern() : base('=', ETokenType.Assign)
        {
        }
    }
}