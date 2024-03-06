namespace Lox.Compiler.Common
{
    public interface ILogger
    {
        void WriteInfo(string text);
        void WriteError(string text);
    }
}