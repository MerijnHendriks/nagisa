namespace Lox.Compiler.Lexing.Patterns
{
    public sealed class AssignPattern : CharacterPattern
    {
        public AssignPattern() : base('=', ETokenType.Assign)
        {
        }
    }
}