/*  NOTE:
    Be VERY careful when modifying PattternProvider._patterns, order is extremely important here;
    Correctness: Cases like "+=" MUST be matched BEFORE "+", otherwise "+=" will be detected as "+", "=".
    Performance: Common cases MUST match ASAP, othterwise performance degrades significantly.
*/

using System.Collections.Generic;
using Nagisa.Core.Lexing;

namespace Nagisa.Lox.Lexing
{
    public class LoxPatterns
    {
        public readonly List<Pattern> Patterns;

        public LoxPatterns()
        {
            this.Patterns = new List<Pattern>();

            // --- Text file
            this.Patterns.Add(new CharacterPattern(' ', TokenType.WHITESPACE));
            this.Patterns.Add(new CharacterPattern('\t', TokenType.TAB));
            this.Patterns.Add(new NewlinePattern());

            // --- Comments
            this.Patterns.Add(new LineCommentPattern());

            // --- Operators
            this.Patterns.Add(new CharacterPattern('.', TokenType.DOT));
            this.Patterns.Add(new CharacterPattern(',', TokenType.COMMA));
            this.Patterns.Add(new CharacterPattern(';', TokenType.SEMICOLON));
            this.Patterns.Add(new CharacterPattern('{', TokenType.LEFT_CURLY));
            this.Patterns.Add(new CharacterPattern('}', TokenType.RIGHT_CURLY));
            this.Patterns.Add(new CharacterPattern('(', TokenType.LEFT_CIRCLE));
            this.Patterns.Add(new CharacterPattern(')', TokenType.RIGHT_CIRCLE));
            this.Patterns.Add(new TextPattern("==", TokenType.EQUAL));
            this.Patterns.Add(new CharacterPattern('=', TokenType.ASSIGN));
            this.Patterns.Add(new TextPattern("!=", TokenType.NOT_EQUAL));
            this.Patterns.Add(new CharacterPattern('!', TokenType.NOT));
            this.Patterns.Add(new TextPattern("<=", TokenType.LESS_EQUAL));
            this.Patterns.Add(new CharacterPattern('<', TokenType.LEFT_ARROW));
            this.Patterns.Add(new TextPattern(">=", TokenType.GREATER_EQUAL));
            this.Patterns.Add(new CharacterPattern('>', TokenType.RIGHT_ARROW));
            this.Patterns.Add(new TextPattern("+=", TokenType.ADD_ASSIGN));
            this.Patterns.Add(new CharacterPattern('+', TokenType.PLUS));
            this.Patterns.Add(new TextPattern("-=", TokenType.SUBSTRACT_ASSIGN));
            this.Patterns.Add(new CharacterPattern('-', TokenType.MINUS));
            this.Patterns.Add(new TextPattern("*=", TokenType.MULTIPLY_ASSIGN));
            this.Patterns.Add(new CharacterPattern('*', TokenType.STAR));
            this.Patterns.Add(new TextPattern("/=", TokenType.DIVIDE_ASSIGN));
            this.Patterns.Add(new CharacterPattern('/', TokenType.SLASH));

            // --- Keywords
            this.Patterns.Add(new TextPattern("if", TokenType.IF));
            this.Patterns.Add(new TextPattern("else", TokenType.ELSE));
            this.Patterns.Add(new TextPattern("while", TokenType.WHILE));
            this.Patterns.Add(new TextPattern("for", TokenType.FOR));
            this.Patterns.Add(new TextPattern("and", TokenType.AND));
            this.Patterns.Add(new TextPattern("or", TokenType.OR));
            this.Patterns.Add(new TextPattern("return", TokenType.RETURN));
            this.Patterns.Add(new TextPattern("break", TokenType.BREAK));
            this.Patterns.Add(new TextPattern("continue", TokenType.CONTINUE));
            this.Patterns.Add(new TextPattern("false", TokenType.FALSE));
            this.Patterns.Add(new TextPattern("true", TokenType.TRUE));
            this.Patterns.Add(new TextPattern("nil", TokenType.NIL));
            this.Patterns.Add(new TextPattern("var", TokenType.VAR));
            this.Patterns.Add(new TextPattern("fun", TokenType.FUN));
            this.Patterns.Add(new TextPattern("class", TokenType.CLASS));
            this.Patterns.Add(new TextPattern("this", TokenType.THIS));
            this.Patterns.Add(new TextPattern("super", TokenType.SUPER));

            // --- Build-in functions
            // TODO: move this to VM bindings or standard library
            this.Patterns.Add(new TextPattern("print", TokenType.PRINT));

            // --- Expensive lookups
            this.Patterns.Add(new NumberPattern());
            this.Patterns.Add(new StringPattern());
            this.Patterns.Add(new IdentifierPattern());
        }
    }
}