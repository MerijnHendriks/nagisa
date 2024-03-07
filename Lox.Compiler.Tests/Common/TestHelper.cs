using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Lox.Compiler.Lexing;

namespace Lox.Compiler.Tests.Common
{
    public sealed class TestHelper
    {
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
    }
}