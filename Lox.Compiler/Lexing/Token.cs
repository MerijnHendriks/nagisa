namespace Lox.Compiler.Lexing
{
    public sealed class Token
    {
        public readonly string File;
        public readonly int Index;
        public readonly int Type;
        public readonly object Value;

        public Token()
        {
            this.File = string.Empty;
            this.Index = 0;
            this.Type = TokenType.INVALID;
            this.Value = null;
        }

        public Token(string file, int index, int type, object value)
        {
            this.File = file;
            this.Index = index;
            this.Type = type;
            this.Value = value;
        }
    }
}