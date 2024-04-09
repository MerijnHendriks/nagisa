using System;

namespace Lox.Compiler.Lexing
{
    public sealed class PatternMatchingException : Exception
    {
        public PatternMatchingException(string message) : base(message)
        {
            // empty
        }
    }
}