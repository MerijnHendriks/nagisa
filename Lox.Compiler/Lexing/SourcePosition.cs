namespace Lox.Compiler.Lexing
{
    public sealed class SourcePosition
    {
        public readonly string File;

        // Mutated in Scanner,Pattern
        public int Index;

        // Mutated in Scanner,Pattern               
        public int Line;

        // Mutated in Scanner,Pattern        
        public int Column;

        public SourcePosition(string file, int index, int line, int column)
        {
            this.File = file;
            this.Index = index;
            this.Line = line;
            this.Column = column;
        }
    }
}