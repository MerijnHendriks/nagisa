using System.Collections.Generic;
using Nagisa.Core.Common;
using Nagisa.Core.Lexing;
using Nagisa.Core.Parsing;
using Nagisa.Core.Parsing.Expressions;
using Nagisa.Core.Execution;

namespace Nagisa.Core
{
    public sealed class Compiler
    {
        private readonly Logger _logger;
        private readonly Scanner _scanner;
        private readonly Parser _parser;
        private readonly MermaidGenerator _mermaidGenerator;
        private readonly Interpreter _interpreter;

        public Compiler(Logger logger, List<Pattern> patterns)
        {
            this._logger = logger;
            this._scanner = new Scanner(logger, patterns);
            this._parser = new Parser(logger);
            this._mermaidGenerator = new MermaidGenerator(logger);
            this._interpreter = new Interpreter(logger);
        }

        public void Run(string file, string source)
        {
            // Get tokens
            List<Token> tokens = this._scanner.Run(file, source);

            // Remove tokens unused by parser (reverse order)
            for (int i = tokens.Count - 1; i >= 0; i -= 1)
            {
                Token token = tokens[i];

                if (token.Type == TokenType.LINE_COMMENT
                    || token.Type == TokenType.WHITESPACE
                    || token.Type == TokenType.TAB
                    || token.Type == TokenType.END_OF_LINE)
                {
                    tokens.RemoveAt(i);
                }
            }

            // Convert tokens to AST
            Expr ast = this._parser.Run(tokens);

            // Print mermaid diagram
            string diagram = this._mermaidGenerator.Generate(ast);
            this._logger.WriteInfo(diagram);

            // Execute code
            string log = this._interpreter.Interpret(ast);
            this._logger.WriteInfo(log);
        }
    }
}