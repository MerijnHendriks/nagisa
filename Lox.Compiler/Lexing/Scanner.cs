/*  NOTE:
    Be VERY careful when modifying Scanner._patterns, order is extremely important here;
    Correctness: Cases like "+=" MUST be matched BEFORE "+", otherwise "+=" will be detected as "+", "=".
    Performance: Common cases MUST match ASAP, othterwise performance degrades significantly.
*/

using System;
using System.Collections.Generic;
using Lox.Compiler.Common;
using Lox.Compiler.Lexing.Patterns;

namespace Lox.Compiler.Lexing
{
    public sealed class Scanner
    {
        private readonly Logger _logger;
        private readonly TextHelper _textHelper;
        private readonly Pattern[] _patterns;

        public Scanner(Logger logger, Pattern[] patterns)
        {
            this._logger = logger;
            this._textHelper = new TextHelper();
            this._patterns = patterns;
        }

        private SourcePosition ScanToken(string file, string source, SourcePosition current, ref Token token)
        {
            for (int i = 0; i < this._patterns.Length; ++i)
            {
                Pattern pattern = this._patterns[i];

                if (!pattern.IsMatch(source, current))
                {
                    continue;
                }

                return pattern.Run(file, source, current, ref token);
            }

            string format = "[{0}]: No matching pattern for {1} at [idx:{2},ln:{3},col:{4}].";
            string error = string.Format(format, file, source[current.Index], current.Index, current.Line, current.Column);
            throw new Exception(error);
        }

        private void PrintToken(Token token, SourcePosition current)
        {
            string format = "[{0}, {1}, {2}] {3}";
            string typeName = _textHelper.GetTokenTypeName(token.Type);
            string formatted = string.Format(format, current.Index, current.Line, current.Column, typeName);

            if (!string.IsNullOrEmpty(token.Value))
            {
                formatted += (", " + token.Value);
            }

            _logger.WriteInfo(formatted);
        }

        public ScanResult Run(string file, string source)
        {
            Token token = new Token();
            SourcePosition current = new SourcePosition(file, 0, 1, 1);
            SourcePosition next = current;
            ScanResult result = new ScanResult();

            // Tokenize source
            while (!this._textHelper.IsAtEnd(source, current.Index))
            {
                next = this.ScanToken(file, source, current, ref token);

                if (token.Type != TokenType.INVALID)
                {
                    // Add to result
                    result.Tokens.Add(token);
                    result.Sourcemap.Add(current);

                    // Print
                    this.PrintToken(token, current);
                }

                current = next;
            }

            // Add End-Of-File token
            token = new Token(file, current.Index, TokenType.END_OF_FILE, string.Empty);
            result.Tokens.Add(token);
            result.Sourcemap.Add(current);
            this.PrintToken(token, current);

            return result;
        }
    }
}