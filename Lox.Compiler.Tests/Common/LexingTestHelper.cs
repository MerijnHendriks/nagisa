using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lox.Compiler.Common;
using Lox.Compiler.Lexing;
using Lox.Compiler.Lexing.Patterns;

namespace Lox.Compiler.Tests.Common
{
    public static class LexingTestHelper
    {
        private static readonly Logger _logger;
        private static readonly Scanner _scanner;

        static LexingTestHelper()
        {
            var patternProvider = new PatternProvider();
            var patterns = patternProvider.GetPatterns();

            _logger = new TestLogger();
            _scanner = new Scanner(_logger, patterns);
        }

        public static void AssertToken(Token truth, Token other)
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

        public static void AssertSourcePosition(SourcePosition truth, SourcePosition other)
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

        public static void AssertPatternIsMatch(Pattern pattern, string file, string source, bool expected)
        {
            if (pattern == null)
            {
                Assert.Fail("No input pattern.");
            }

            if (string.IsNullOrEmpty(source))
            {
                Assert.Fail("No input source.");
            }

            var current = new SourcePosition(file, 0, 1, 1);
            var result = pattern.IsMatch(source, current);

            Assert.IsTrue(result == expected);
        }

        public static void AssertPatternRun(Pattern pattern, string file, string source, Token token, SourcePosition next)
        {
            if (pattern == null)
            {
                Assert.Fail("No input pattern.");
            }

            if (string.IsNullOrEmpty(source))
            {
                Assert.Fail("No input source.");
            }

            if (token == null)
            {
                Assert.Fail("No input token.");
            }

            if (next == null)
            {
                Assert.Fail("No input next.");
            }

            var current = new SourcePosition(file, 0, 1, 1);
            var resultToken = new Token();
            var resultNext = pattern.Run(file, source, current, ref resultToken);

            AssertToken(token, resultToken);
            AssertSourcePosition(next, resultNext);
        }

        public static void AssertScanner(string source, Token[] tokens, SourcePosition[] sourcemap)
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
                AssertToken(tokens[i], result.Tokens[i]);
            }

            for (var i = 0; i < sourcemap.Length; ++i)
            {
                AssertSourcePosition(sourcemap[i], result.Sourcemap[i]);
            }
        }
    }
}