namespace Lox.Compiler.Lexing
{
    public sealed class SourcePosition
    {
        public readonly string File;
        public int Index;               // mutated in Scanner/Pattern
        public int Line;                // mutated in Scanner/Pattern
        public int Column;              // mutated in Scanner/Pattern

        public SourcePosition(string file, int index, int line, int column)
        {
            this.File = file;
            this.Index = index;
            this.Line = line;
            this.Column = column;
        }
    }
}