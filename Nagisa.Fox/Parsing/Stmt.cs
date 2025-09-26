namespace Nagisa.Fox.Parsing
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