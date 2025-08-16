namespace Lox.Compiler.Parsing.Expressions
{
    public abstract class Expr
    {
        public EExpr Type;

        public Expr(EExpr type)
        {
            this.Type = type;
        }
    }
}