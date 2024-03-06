using System;
using System.Collections.Generic;

namespace Lox.Compiler.Lexing.Patterns
{
    public abstract class Pattern
    {
        public abstract bool IsMatch(string source, SourcePosition current);
        public abstract SourcePosition Run(string file, string source, SourcePosition current, ref Token token);

        // TODO: better naming of method
        protected SourcePosition RunOffset(string file, string source, SourcePosition current, ref Token token, ETokenType type, int offset)
        {
            // get token
            token = new Token(file, current.Index, type, string.Empty);

            // get position
            int nextIndex = current.Index + offset;
            int nextColumn = current.Column + offset;
            SourcePosition next = new SourcePosition(file, nextIndex, current.Line, nextColumn);
            
            return next;
        }
    }
}