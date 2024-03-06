/* NOTE:
   C# 2.0 doesn't support parameterless constructors for structs and the data
   inside this structure is mutated, hence this being a class.
*/

using System.Collections.Generic;

namespace Lox.Compiler.Lexing
{
    public sealed class ScanResult
    {
        public readonly List<Token> Tokens;
        public readonly List<SourcePosition> Sourcemap;

        public ScanResult()
        {
            this.Tokens = new List<Token>();
            this.Sourcemap = new List<SourcePosition>();
        }
    }
}