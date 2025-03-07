/*  NOTE:
    Be VERY careful when modifying PattternProvider._patterns, order is extremely important here;
    Correctness: Cases like "+=" MUST be matched BEFORE "+", otherwise "+=" will be detected as "+", "=".
    Performance: Common cases MUST match ASAP, othterwise performance degrades significantly.
*/

using Lox.Compiler.Lexing.Patterns;

namespace Lox.Compiler.Lexing
{
    public sealed class PatternProvider
    {
        private readonly Pattern[] _patterns;

        public PatternProvider()
        {
            this._patterns = new Pattern[]
            {
                // --- Text file
                new CharacterPattern(' ', TokenType.WHITESPACE),
                new CharacterPattern('\t', TokenType.TAB),
                new NewlinePattern(),
                // --- Comments
                new LineCommentPattern(),
                // --- Operators
                new CharacterPattern('.', TokenType.DOT),
                new CharacterPattern(',', TokenType.COMMA),
                new CharacterPattern(';', TokenType.SEMICOLON),
                new CharacterPattern('{', TokenType.LEFT_CURLY),
                new CharacterPattern('}', TokenType.RIGHT_CURLY),
                new CharacterPattern('(', TokenType.LEFT_CIRCLE),
                new CharacterPattern(')', TokenType.RIGHT_CIRCLE),
                new TextPattern("==", TokenType.EQUAL),
                new CharacterPattern('=', TokenType.ASSIGN),
                new TextPattern("!=", TokenType.NOT_EQUAL),
                new CharacterPattern('!', TokenType.NOT),
                new TextPattern("<=", TokenType.LESS_EQUAL),
                new CharacterPattern('<', TokenType.LEFT_ARROW),
                new TextPattern(">=", TokenType.GREATER_EQUAL),
                new CharacterPattern('>', TokenType.RIGHT_ARROW),
                new TextPattern("+=", TokenType.ADD_ASSIGN),
                new CharacterPattern('+', TokenType.PLUS),
                new TextPattern("-=", TokenType.SUBSTRACT_ASSIGN),
                new CharacterPattern('-', TokenType.MINUS),                
                new TextPattern("*=", TokenType.MULTIPLY_ASSIGN),
                new CharacterPattern('*', TokenType.STAR),
                new TextPattern("/=", TokenType.DIVIDE_ASSIGN),
                new CharacterPattern('/', TokenType.SLASH),
                // --- Keywords
                new TextPattern("if", TokenType.IF),
                new TextPattern("else", TokenType.ELSE),
                new TextPattern("while", TokenType.WHILE),
                new TextPattern("for", TokenType.FOR),
                new TextPattern("and", TokenType.AND),
                new TextPattern("or", TokenType.OR),
                new TextPattern("return", TokenType.RETURN),
                new TextPattern("break", TokenType.BREAK),
                new TextPattern("continue", TokenType.CONTINUE),
                new TextPattern("false", TokenType.FALSE),
                new TextPattern("true", TokenType.TRUE),
                new TextPattern("nil", TokenType.NIL),
                new TextPattern("var", TokenType.VAR),
                new TextPattern("fun", TokenType.FUN),
                new TextPattern("class", TokenType.CLASS),
                new TextPattern("this", TokenType.THIS),
                new TextPattern("super", TokenType.SUPER),
                // --- Build-in functions
                // TODO: move this to VM bindings or standard library
                new TextPattern("print", TokenType.PRINT),
                // --- Expensive lookups
                new NumberPattern(),
                new StringPattern(),
                new IdentifierPattern()
            };
        }

        public Pattern[] GetPatterns()
        {
            return this._patterns;
        }
    }
}