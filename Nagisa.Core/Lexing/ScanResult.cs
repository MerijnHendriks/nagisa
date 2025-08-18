using System.Collections.Generic;

namespace Nagisa.Core.Lexing
{
    public sealed class ScanResult
    {
        // Mutated in Interpreter,Scanner
        public readonly List<Token> Tokens;

        // Mutated in Interpreter,Scanner
        public readonly List<SourcePosition> Sourcemap;

        public ScanResult()
        {
            this.Tokens = new List<Token>();
            this.Sourcemap = new List<SourcePosition>();
        }
    }
}