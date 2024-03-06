namespace Lox.Compiler.Common
{
    public abstract class Logger
    {
        public abstract void WriteInfo(string text);
        public abstract void WriteError(string text);
    }
}