namespace Lox.Compiler.Parsing.Expressions
{
    public abstract class Expr
    {
        public readonly int Type;

        public Expr(int type)
        {
            this.Type = type;
        }
    }
}