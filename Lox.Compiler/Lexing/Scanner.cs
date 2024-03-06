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

        public Scanner(Logger logger)
        {
            this._logger = logger;
            this._textHelper = new TextHelper();
            this._patterns = new Pattern[]
            {
                // --- Text file
                new WhitespacePattern(),
                new TabPattern(),
                new NewlinePattern(),
                // --- Comments
                new LineCommentPattern(),
                // --- Operators
                new DotPattern(),
                new CommaPattern(),
                new SemicolonPattern(),
                new LeftCurlyPattern(),
                new RightCurlyPattern(),
                new LeftCirclePattern(),
                new RightCirclePattern(),
                // new LeftSquarePattern(),
                // new RightSquarePattern(),
                new EqualPattern(),
                new AssignPattern(),
                new NotEqualPattern(),
                new NotPattern(),
                new LessEqualPattern(),
                // new BitShiftLeft(),
                new LeftArrowPattern(),
                new GreaterEqualPattern(),
                // new BitShiftRight(),
                new RightArrowPattern(),
                new AddAssignPattern(),
                new PlusPattern(),
                new SubstractAssignPattern(),
                new MinusPattern(),                
                new MultiplyAssignPattern(),
                new StarPattern(),
                new DivideAssignPattern(),
                new SlashPattern(),
                // new AndOperatorPattern(),
                // new OrOperatorPattern(),
                // new BitwiseAndPattern(),
                // new BitwiseOrPattern(),
                // new BitwiseXorPattern(),
                // new BitwiseComplement(),
                // --- Keywords
                new IfPattern(),
                new ElsePattern(),
                new WhilePattern(),
                new ForPattern(),
                new AndKeywordPattern(),
                new OrKeywordPattern(),
                new ReturnPattern(),
                new BreakPattern(),
                new ContinuePattern(),
                new FalsePattern(),
                new TruePattern(),
                new NilPattern(),
                new VarPattern(),
                new FunPattern(),
                new ClassPattern(),
                new ThisPattern(),
                new SuperPattern(),
                // --- Build-in functions
                // TODO: move this to VM bindings or standard library
                new PrintPattern(),
                // --- Expensive lookups
                new NumberPattern(),
                new StringPattern(),
                new IdentifierPattern()
            };
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

        private void PrintToken(Token token, SourcePosition current, SourcePosition next)
        {
            string format = "[{0}, {1}, {2}] {3}";
            string formatted = string.Format(format, current.Index, current.Line, current.Column, token.Type);

            if (!string.IsNullOrEmpty(token.Value))
            {
                formatted += (", " + token.Value);
            }

            _logger.WriteInfo(formatted);
        }

        public ScanResult Run(string file, string source)
        {
            Token token = new Token();
            SourcePosition current = new SourcePosition(file, 0, 1, 0);
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
                    this.PrintToken(token, current, next);
                }

                current = next;
            }

            // Add End-Of-File token
            token = new Token(file, current.Index, TokenType.END_OF_FILE, string.Empty);
            result.Tokens.Add(token);
            result.Sourcemap.Add(current);

            return result;
        }
    }
}