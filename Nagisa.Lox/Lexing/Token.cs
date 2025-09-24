namespace Nagisa.Lox.Lexing
{
    public sealed class Token
    {
        public readonly string File;
        public readonly int Index;            
        public readonly int Line;     
        public readonly int Column;
        public readonly int Type;
        public readonly string Value;

        public Token()
        {
            this.File = string.Empty;
            this.Index = 0;
            this.Line = 0;
            this.Column = 0;
            this.Type = TokenType.INVALID;
            this.Value = null;
        }

        public Token(string file, int index, int line, int column, int type, string value)
        {
            this.File = file;
            this.Index = index;
            this.Line = line;
            this.Column = column;
            this.Type = type;
            this.Value = value;
        }

        public Token(string file, SourcePosition position, int type, string value)
        {
            this.File = file;
            this.Index = position.Index;
            this.Line = position.Line;
            this.Column = position.Column;
            this.Type = type;
            this.Value = value;
        }
    }
}