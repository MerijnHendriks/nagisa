using Lox.Compiler.Common;
using Lox.Compiler.Lexing;
using Lox.Compiler.Lexing.Patterns;
using Lox.Compiler.Parsing;
using Lox.Compiler.Parsing.Expressions;
using Lox.Compiler.Execution;

namespace Lox.Compiler
{
    public sealed class Compiler
    {
        private readonly Scanner _scanner;
        private readonly Parser _parser;
        private readonly Interpreter _interpreter;

        public Compiler(Logger logger)
        {
            PatternProvider patternProvider = new PatternProvider();
            Pattern[] patterns = patternProvider.GetPatterns();

            this._scanner = new Scanner(logger, patterns);
            this._parser = new Parser(logger);
            this._interpreter = new Interpreter(logger);
        }

        public void Run(string file, string source)
        {
            // Get tokens
            ScanResult result = this._scanner.Run(file, source);

            // Remove tokens unused by parser (reverse order)
            for (int i = result.Tokens.Count - 1; i >= 0; i -= 1)
            {
                Token token = result.Tokens[i];

                if (token.Type == TokenType.LINE_COMMENT
                    || token.Type == TokenType.WHITESPACE
                    || token.Type == TokenType.TAB
                    || token.Type == TokenType.END_OF_LINE)
                {
                    result.Tokens.RemoveAt(i);
                    result.Sourcemap.RemoveAt(i);
                }
            }

            // Convert tokens to AST
            Expr ast = this._parser.Run(result);

            // Execute code
            this._interpreter.Interpret(ast);
        }
    }
}