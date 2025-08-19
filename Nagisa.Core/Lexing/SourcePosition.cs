namespace Nagisa.Core.Lexing
{
    public sealed class SourcePosition
    {
        // Mutated in Scanner,Pattern
        public int Index;

        // Mutated in Scanner,Pattern               
        public int Line;

        // Mutated in Scanner,Pattern        
        public int Column;

        public SourcePosition(int index, int line, int column)
        {
            this.Index = index;
            this.Line = line;
            this.Column = column;
        }
    }
}