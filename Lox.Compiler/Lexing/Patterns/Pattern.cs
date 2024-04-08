namespace Lox.Compiler.Lexing.Patterns
{
    public abstract class Pattern
    {
        public abstract bool IsMatch(string source, SourcePosition current);
        public abstract SourcePosition Run(string file, string source, SourcePosition current, ref Token token);

        protected SourcePosition RunOffset(string file, string source, SourcePosition current, ref Token token, int type, int offset)
        {
            // Get token
            token = new Token(file, current.Index, type, string.Empty);

            // Get position
            int nextIndex = current.Index + offset;
            int nextColumn = current.Column + offset;
            SourcePosition next = new SourcePosition(file, nextIndex, current.Line, nextColumn);
            
            return next;
        }
    }
}