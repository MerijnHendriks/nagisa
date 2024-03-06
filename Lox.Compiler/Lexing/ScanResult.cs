using System.Collections.Generic;

namespace Lox.Compiler.Lexing
{
    public sealed class ScanResult
    {
        public readonly List<Token> Tokens;             // Mutated in Interpreter,Scanner
        public readonly List<SourcePosition> Sourcemap; // Mutated in Interpreter,Scanner

        public ScanResult()
        {
            this.Tokens = new List<Token>();
            this.Sourcemap = new List<SourcePosition>();
        }
    }
}