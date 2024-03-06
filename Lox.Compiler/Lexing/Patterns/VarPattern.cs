namespace Lox.Compiler.Lexing.Patterns
{
    public sealed class VarPattern : TextPattern
    {
        public VarPattern() : base("var", TokenType.VAR)
        {
        }
    }
}