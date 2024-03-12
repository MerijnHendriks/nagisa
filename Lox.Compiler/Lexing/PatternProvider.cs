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
                new WhitespacePattern(),
                new TabPattern(),
                new NewlinePattern(),
                // --- Comments
                new LineCommentPattern(),
                // --- Operators
                new DotPattern(),
                new CommaPattern(),
                new SemicolonPattern(),
                new LeftCurlyPattern(),
                new RightCurlyPattern(),
                new LeftCirclePattern(),
                new RightCirclePattern(),
                new LeftSquarePattern(),
                new RightSquarePattern(),
                new EqualPattern(),
                new AssignPattern(),
                new NotEqualPattern(),
                new NotPattern(),
                new LessEqualPattern(),
                new BitShiftLeftPattern(),
                new LeftArrowPattern(),
                new GreaterEqualPattern(),
                new BitShiftRightPattern(),
                new RightArrowPattern(),
                new AddAssignPattern(),
                new PlusPattern(),
                new SubstractAssignPattern(),
                new MinusPattern(),                
                new MultiplyAssignPattern(),
                new StarPattern(),
                new DivideAssignPattern(),
                new SlashPattern(),
                new AndOperatorPattern(),
                new OrOperatorPattern(),
                new BitwiseAndPattern(),
                new BitwiseOrPattern(),
                new BitwiseXorPattern(),
                new BitwiseComplementPattern(),
                // --- Keywords
                new IfPattern(),
                new ElsePattern(),
                new WhilePattern(),
                new ForPattern(),
                new AndKeywordPattern(),
                new OrKeywordPattern(),
                new ReturnPattern(),
                new BreakPattern(),
                new ContinuePattern(),
                new FalsePattern(),
                new TruePattern(),
                new NilPattern(),
                new VarPattern(),
                new FunPattern(),
                new ClassPattern(),
                new ThisPattern(),
                new SuperPattern(),
                // --- Build-in functions
                // TODO: move this to VM bindings or standard library
                new PrintPattern(),
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