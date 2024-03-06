namespace Lox.Compiler.Lexing
{
    public struct Token
    {
        public string File;
        public int Index;
        public ETokenType Type;
        public string Value;

        public Token(string file, int index, ETokenType type, string value)
        {
            this.File = file;
            this.Index = index;
            this.Type = type;
            this.Value = value;
        }
    }
}