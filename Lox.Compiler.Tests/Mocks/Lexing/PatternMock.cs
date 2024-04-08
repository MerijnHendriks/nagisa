using System;
using Lox.Compiler.Lexing;
using Lox.Compiler.Lexing.Patterns;

namespace Lox.Compiler.Tests.Mocks.Lexing
{
    public sealed class PatternMock : Pattern
    {
        private readonly int _type;
        private readonly int _offset;

        public PatternMock()
        {
            this._type = TokenType.IDENTIFIER; 
            this._offset = 1;
        }

        public override bool IsMatch(string source, SourcePosition current)
        {
            throw new NotImplementedException();
        }

        public override SourcePosition Run(string file, string source, SourcePosition current, ref Token token)
        {
            return this.RunOffset(file, source, current, ref token, this._type, this._offset);
        }
    }
}