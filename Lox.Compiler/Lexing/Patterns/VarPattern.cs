namespace Lox.Compiler.Lexing.Patterns
{
    public class VarPattern : TextPattern
    {
        public VarPattern() : base("var", ETokenType.Variable)
        {
        }
    }
}