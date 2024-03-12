using System;
using System.Collections.Generic;
using Lox.Compiler.Common;
using Lox.Compiler.Lexing;
using Lox.Compiler.Lexing.Patterns;
using Lox.Compiler.Parsing;

namespace Lox.Compiler
{
    public sealed class Interpreter
    {
        private readonly Logger _logger;
        private readonly Scanner _scanner;

        public Interpreter(Logger logger)
        {
            PatternProvider patternProvider = new PatternProvider();
            Pattern[] patterns = patternProvider.GetPatterns();

            this._logger = logger;
            this._scanner = new Scanner(logger, patterns);
        }

        public void RunSingle(string file, string source)
        {
            // Get tokens
            ScanResult result = this._scanner.Run(file, source);

            // Remove tokens unused by parser (reverse order)
            for (int i = result.Tokens.Count - 1; i >= 0; --i)
            {
                Token token = result.Tokens[i];

                if (token.Type == TokenType.LINE_COMMENT
                    || token.Type == TokenType.WHITESPACE
                    || token.Type == TokenType.TAB
                    || token.Type == TokenType.END_OF_LINE
                    || token.Type == TokenType.END_OF_FILE)
                {
                    result.Tokens.RemoveAt(i);
                    result.Sourcemap.RemoveAt(i);
                }
            }

            // Convert tokens to AST
            Parser parser = new Parser();
            parser.Run(result);
        }

        public void RunMulti(string[] files, string[] sources)
        {
            if (files.Length != sources.Length)
            {
                throw new Exception("files and sources length not equal.");
            }

            for (int i = 0; i < files.Length; ++i)
            {
                RunSingle(files[i], sources[i]);
            }
        }
    }
}