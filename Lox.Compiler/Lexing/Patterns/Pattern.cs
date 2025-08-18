namespace Lox.Compiler.Lexing.Patterns
{
    public abstract class Pattern
    {
        public abstract bool IsMatch(string source, SourcePosition current);
        public abstract MatchResult Run(string file, string source, SourcePosition current);

        protected MatchResult RunOffset(string file, string source, SourcePosition current, int type, int offset)
        {
            Token token = new Token(file, current.Index, type, null);

            int nextIndex = current.Index + offset;
            int nextColumn = current.Column + offset;
            SourcePosition next = new SourcePosition(file, nextIndex, current.Line, nextColumn);

            return new MatchResult(token, next);
        }
    }
}