namespace Lox.Compiler.Parsing.Statements
{
    public interface IStatementVisitor<T>
    {
        T VisitBlockStmt(Block Stmt);
        T VisitClassStmt(Class Stmt);
        T VisitExpressionStmt(Expression Stmt);
        T VisitFunctionStmt(Function Stmt);
        T VisitIfStmt(If Stmt);
        T VisitPrintStmt(Print Stmt);
        T VisitReturnStmt(Return Stmt);
        T VisitVarStmt(Var Stmt);
        T VisitWhileStmt(While Stmt);
    }
}