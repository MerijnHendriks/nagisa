using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Lox.Compiler.Common;
using Lox.Compiler.Lexing;
using Lox.Compiler.Lexing.Patterns;

namespace Lox.Compiler.Tests.Common
{
    public sealed class LexingTestHelper
    {
        private readonly Logger _logger;
        private readonly Scanner _scanner;

        public LexingTestHelper()
        {
            var patternProvider = new PatternProvider();
            var patterns = patternProvider.GetPatterns();

            _logger = new TestLogger();
            _scanner = new Scanner(_logger, patterns);
        }

        public void AssertToken(Token truth, Token other)
        {
            if (other.File != truth.File)
            {
                Assert.Fail($"Token.File is incorrect. Expected {truth.File}, got {other.File}.");
            }

            if (other.Index != truth.Index)
            {
                Assert.Fail($"Token.Index is incorrect. Expected {truth.Index}, got {other.Index}.");
            }

            if (other.Type != truth.Type)
            {
                Assert.Fail($"Token.Type is incorrect. Expected {truth.Type}, got {other.Type}.");
            }

            if (other.Value != truth.Value)
            {
                Assert.Fail($"Token.Value is incorrect. Expected {truth.Value}, got {other.Value}.");
            }
        }

        public void AssertSourcePosition(SourcePosition truth, SourcePosition other)
        {
            if (other.File != truth.File)
            {
                Assert.Fail($"SourcePosition.File is incorrect. Expected {truth.File}, got {other.File}.");
            }

            if (other.Index != truth.Index)
            {
                Assert.Fail($"SourcePosition.Index is incorrect. Expected {truth.Index}, got {other.Index}.");
            }

            if (other.Line != truth.Line)
            {
                Assert.Fail($"SourcePosition.Line is incorrect. Expected {truth.Line}, got {other.Line}.");
            }

            if (other.Column != truth.Column)
            {
                Assert.Fail($"SourcePosition.Column is incorrect. Expected {truth.Column}, got {other.Column}.");
            }
        }

        public void AssertPatternIsMatch(Pattern pattern, string source, SourcePosition current, bool expected)
        {
            if (pattern == null)
            {
                Assert.Fail("No input pattern.");
            }

            if (string.IsNullOrEmpty(source))
            {
                Assert.Fail("No input source.");
            }

            if (current == null)
            {
                Assert.Fail("No input current.");
            }

            var result = pattern.IsMatch(source, current);
            Assert.IsTrue(result == expected);
        }

        public void AssertPatternRun(Pattern pattern, string file, string source, SourcePosition current, Token token, SourcePosition next)
        {
            if (pattern == null)
            {
                Assert.Fail("No input pattern.");
            }

            if (string.IsNullOrEmpty(source))
            {
                Assert.Fail("No input source.");
            }

            if (current == null)
            {
                Assert.Fail("No input current.");
            }

            if (token == null)
            {
                Assert.Fail("No input token.");
            }

            if (next == null)
            {
                Assert.Fail("No input next.");
            }

            var resultToken = new Token();
            var resultNext = pattern.Run(file, source, current, ref resultToken);

            this.AssertToken(token, resultToken);
            this.AssertSourcePosition(next, resultNext);
        }

        public void AssertScanner(string source, Token[] tokens, SourcePosition[] sourcemap)
        {
            if (string.IsNullOrEmpty(source))
            {
                Assert.Fail("No input source.");
            }

            if (tokens == null || tokens.Length == 0)
            {
                Assert.Fail("No input tokens.");
            }

            if (sourcemap == null || sourcemap.Length == 0)
            {
                Assert.Fail("No input sourcemap.");
            }

            if (tokens.Length != sourcemap.Length)
            {
                Assert.Fail("Input tokens and sourcemap not of equal length.");
            }

            var result = _scanner.Run(string.Empty, source);

            if (result.Tokens.Count != tokens.Length)
            {
                Assert.Fail($"result.Tokens.Count incorrect. Expected {tokens.Length}, got {result.Tokens.Count}.");
            }

            if (result.Sourcemap.Count != sourcemap.Length)
            {
                Assert.Fail($"result.Sourcemap.Count incorrect. Expected {sourcemap.Length}, got {result.Sourcemap.Count}.");
            }

            if (result.Tokens.Count != result.Sourcemap.Count)
            {
                Assert.Fail("Result tokens and sourcemap not of equal length.");
            }

            for (var i = 0; i < tokens.Length; ++i)
            {
                this.AssertToken(tokens[i], result.Tokens[i]);
            }

            for (var i = 0; i < sourcemap.Length; ++i)
            {
                this.AssertSourcePosition(sourcemap[i], result.Sourcemap[i]);
            }
        }
    }
}