namespace Lox.Compiler.Lexing.Patterns
{
    public class ThisPattern : TextPattern
    {
        public ThisPattern() : base("this", ETokenType.This)
        {
        }
    }
}