using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nagisa.Fox.Common;
using Nagisa.Fox.Lexing;
using Nagisa.Fox.Lexing.Patterns;

namespace Nagisa.Fox.Tests.Common
{
    public static class LexingTestHelper
    {
        private static readonly Logger _logger;
        private static readonly Scanner _scanner;

        static LexingTestHelper()
        {
            var language = new LoxLanguage();

            _logger = new TestLogger();
            _scanner = new Scanner(_logger, language);
        }

        public static void AssertToken(Token expected, Token result)
        {
            if (result.File != expected.File)
            {
                var format = "Token.File is incorrect. Expected {0}, got {1}.";
                var message = string.Format(format, expected.File, result.File);
                Assert.Fail(message);
            }

            if (result.Index != expected.Index)
            {
                var format = "Token.Index is incorrect. Expected {0}, got {1}.";
                var message = string.Format(format, expected.Index, result.Index);
                Assert.Fail(message);
            }

            if (result.Line != expected.Line)
            {
                var format = "Token.Line is incorrect. Expected {0}, got {1}.";
                var message = string.Format(format, expected.Line, result.Line);
                Assert.Fail(message);
            }

            if (result.Column != expected.Column)
            {
                var format = "Token.Column is incorrect. Expected {0}, got {1}.";
                var message = string.Format(format, expected.Column, result.Column);
                Assert.Fail(message);
            }

            if (result.Type != expected.Type)
            {
                var format = "Token.Type is incorrect. Expected {0}, got {1}.";
                var message = string.Format(format, expected.Type, result.Type);
                Assert.Fail(message);
            }

            if (result.Value != expected.Value)
            {
                var format = "Token.Value is incorrect. Expected {0}, got {1}.";
                var message = string.Format(format, expected.Value, result.Value);
                Assert.Fail(message);
            }
        }

        public static void AssertSourcePosition(SourcePosition expected, SourcePosition result)
        {
            if (result.Index != expected.Index)
            {
                var format = "SourcePosition.Index is incorrect. Expected {0}, got {1}.";
                var message = string.Format(format, expected.Index, result.Index);
                Assert.Fail(message);
            }

            if (result.Line != expected.Line)
            {
                var format = "SourcePosition.Line is incorrect. Expected {0}, got {1}.";
                var message = string.Format(format, expected.Line, result.Line);
                Assert.Fail(message);
            }

            if (result.Column != expected.Column)
            {
                var format = "SourcePosition.Column is incorrect. Expected {0}, got {1}.";
                var message = string.Format(format, expected.Column, result.Column);
                Assert.Fail(message);
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

            var current = new SourcePosition(0, 1, 1);
            var result = pattern.IsMatch(source, current);

            Assert.AreEqual(expected, result);
        }

        public static void AssertPatternRun(Pattern pattern, string file, string source, Token expectedToken, SourcePosition expectedNext)
        {
            if (pattern == null)
            {
                Assert.Fail("No input pattern.");
            }

            if (string.IsNullOrEmpty(source))
            {
                Assert.Fail("No input source.");
            }

            if (expectedToken == null)
            {
                Assert.Fail("No input token.");
            }

            if (expectedNext == null)
            {
                Assert.Fail("No input next.");
            }

            var current = new SourcePosition(0, 1, 1);
            var match = pattern.Run(file, source, current);

            AssertToken(expectedToken, match.Token);
            AssertSourcePosition(expectedNext, match.Position);
        }

        public static void AssertScanner(string source, Token[] expectedTokens)
        {
            if (string.IsNullOrEmpty(source))
            {
                Assert.Fail("No input source.");
            }

            if (expectedTokens == null || expectedTokens.Length == 0)
            {
                Assert.Fail("No input tokens.");
            }

            var result = _scanner.ScanFile(string.Empty, source);

            if (result.Count != expectedTokens.Length)
            {
                var format = "result.Tokens.Count incorrect. Expected {0}, got {1}.";
                var message = string.Format(format, expectedTokens.Length, result.Count);
                Assert.Fail(message);
            }

            for (var i = 0; i < expectedTokens.Length; i += 1)
            {
                AssertToken(expectedTokens[i], result[i]);
            }
        }
    }
}