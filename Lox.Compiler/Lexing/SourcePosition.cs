namespace Lox.Compiler.Lexing
{
    public struct SourcePosition
    {
        public string File;
        public int Index;
        public int Line;
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