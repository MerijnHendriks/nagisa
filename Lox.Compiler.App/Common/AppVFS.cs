using System.IO;

namespace Lox.Compiler.App.Common
{
    public sealed class AppVFS
    {
        public string ReadTextFile(string file)
        {
            return File.ReadAllText(file);
        }
    }
}