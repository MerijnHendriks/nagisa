/*  NOTE:
    Be VERY careful when modifying this.Patterns, order is extremely important here;
    Correctness: Cases like "+=" MUST be matched BEFORE "+", otherwise "+=" will be detected as "+", "=".
    Performance: Common cases MUST match ASAP, othterwise performance degrades significantly.
*/

using System;
using System.Collections.Generic;
using Nagisa.Fox.Lexing;
using Nagisa.Fox.Lexing.Patterns;

namespace Nagisa.Fox
{
    public class FoxLanguage : LanguageData
    {
        public FoxLanguage()
        {
            this.Patterns.Add(new CharacterPattern(' ', TokenType.WHITESPACE));
            this.Patterns.Add(new CharacterPattern('\t', TokenType.TAB));
            this.Patterns.Add(new NewlinePattern());
            this.Patterns.Add(new LineCommentPattern());
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
            this.Patterns.Add(new TextPattern("%=", TokenType.MODULO_ASSIGN));
            this.Patterns.Add(new CharacterPattern('%', TokenType.MODULO));
            this.Patterns.Add(new TextPattern("if", TokenType.IF));
            this.Patterns.Add(new TextPattern("else", TokenType.ELSE));
            this.Patterns.Add(new TextPattern("while", TokenType.WHILE));
            this.Patterns.Add(new TextPattern("for", TokenType.FOR));
            this.Patterns.Add(new TextPattern("&&", TokenType.AND));
            this.Patterns.Add(new TextPattern("||", TokenType.OR));
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
            this.Patterns.Add(new TextPattern("print", TokenType.PRINT));           // TODO: move this to VM bindings or standard library
            this.Patterns.Add(new NumberPattern());
            this.Patterns.Add(new StringPattern());
            this.Patterns.Add(new IdentifierPattern());

            // --- Names
            this.PatternNames.Add(TokenType.END_OF_FILE,       "EOF");
            this.PatternNames.Add(TokenType.END_OF_LINE,       "EOL");
            this.PatternNames.Add(TokenType.DOT,               ".");
            this.PatternNames.Add(TokenType.COMMA,             ",");
            this.PatternNames.Add(TokenType.SEMICOLON,         ";");
            this.PatternNames.Add(TokenType.LEFT_CURLY,        "{");
            this.PatternNames.Add(TokenType.RIGHT_CURLY,       "}");
            this.PatternNames.Add(TokenType.LEFT_CIRCLE,       "(");
            this.PatternNames.Add(TokenType.RIGHT_CIRCLE,      ")");
            this.PatternNames.Add(TokenType.LEFT_ARROW,        "<");
            this.PatternNames.Add(TokenType.RIGHT_ARROW,       ">");
            this.PatternNames.Add(TokenType.ASSIGN,            "=");
            this.PatternNames.Add(TokenType.NOT,               "!");
            this.PatternNames.Add(TokenType.PLUS,              "+");
            this.PatternNames.Add(TokenType.MINUS,             "-");
            this.PatternNames.Add(TokenType.STAR,              "*");
            this.PatternNames.Add(TokenType.SLASH,             "/");
            this.PatternNames.Add(TokenType.EQUAL,             "==");
            this.PatternNames.Add(TokenType.NOT_EQUAL,         "!=");
            this.PatternNames.Add(TokenType.LESS_EQUAL,        "<=");
            this.PatternNames.Add(TokenType.GREATER_EQUAL,     ">=");
            this.PatternNames.Add(TokenType.ADD_ASSIGN,        "+=");
            this.PatternNames.Add(TokenType.SUBSTRACT_ASSIGN,  "-=");
            this.PatternNames.Add(TokenType.MULTIPLY_ASSIGN,   "*=");
            this.PatternNames.Add(TokenType.DIVIDE_ASSIGN,     "/=");
            this.PatternNames.Add(TokenType.IDENTIFIER,        "identifier");
            this.PatternNames.Add(TokenType.NUMBER,            "number");
            this.PatternNames.Add(TokenType.STRING,            "string");
            this.PatternNames.Add(TokenType.TRUE,              "true");
            this.PatternNames.Add(TokenType.FALSE,             "false");
            this.PatternNames.Add(TokenType.NIL,               "nil");
            this.PatternNames.Add(TokenType.THIS,              "this");
            this.PatternNames.Add(TokenType.SUPER,             "super");
            this.PatternNames.Add(TokenType.VAR,               "var");
            this.PatternNames.Add(TokenType.FUN,               "fun");
            this.PatternNames.Add(TokenType.CLASS,             "class");
            this.PatternNames.Add(TokenType.AND,               "&&");
            this.PatternNames.Add(TokenType.OR,                "||");
            this.PatternNames.Add(TokenType.IF,                "if");
            this.PatternNames.Add(TokenType.ELSE,              "else");
            this.PatternNames.Add(TokenType.WHILE,             "while");
            this.PatternNames.Add(TokenType.FOR,               "for");
            this.PatternNames.Add(TokenType.CONTINUE,          "continue");
            this.PatternNames.Add(TokenType.BREAK,             "break");
            this.PatternNames.Add(TokenType.RETURN,            "return");
            this.PatternNames.Add(TokenType.PRINT,             "print");
            this.PatternNames.Add(TokenType.LINE_COMMENT,      "//");
            this.PatternNames.Add(TokenType.TAB,               "\t");
            this.PatternNames.Add(TokenType.WHITESPACE,        "' '");
        }

        public override List<Pattern> GetPatterns()
        {
            return this.Patterns;
        }

        public override string GetTokenName(int type)
        {
            if (type == TokenType.INVALID)
            {
                throw new ArgumentException("Invalid type.");
            }

            if (!this.PatternNames.ContainsKey(type))
            {
                throw new ArgumentException("Invalid type.");
            }

            return this.PatternNames[type];
        }
    }
}