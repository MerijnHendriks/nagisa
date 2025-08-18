using System.IO;

namespace Nagisa.App
{
    public sealed class AppVFS
    {
        public string ReadTextFile(string file)
        {
            return File.ReadAllText(file);
        }
    }
}