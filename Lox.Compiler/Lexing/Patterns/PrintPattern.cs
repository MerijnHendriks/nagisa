// TODO: move this to VM bindings or standard library

namespace Lox.Compiler.Lexing.Patterns
{
    public class PrintPattern : TextPattern
    {
        public PrintPattern() : base("print", ETokenType.Print)
        {
        }
    }
}