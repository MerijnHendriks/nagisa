namespace Nagisa.Core.Parsing.Statements
{
    public abstract class Stmt
    {
        public readonly int Type;

        public Stmt(int type)
        {
            this.Type = type;
        }
    }
}