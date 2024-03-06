namespace Lox.Compiler.Lexing
{
    public sealed class Token
    {
        public readonly string File;
        public readonly int Index;
        public readonly int Type;
        public readonly string Value;

        public Token()
        {
            this.File = string.Empty;
            this.Index = 0;
            this.Type = TokenType.INVALID;
            this.Value = string.Empty;
        }

        public Token(string file, int index, int type, string value)
        {
            this.File = file;
            this.Index = index;
            this.Type = type;
            this.Value = value;
        }
    }
}