using System.Collections.Generic;
using Nagisa.Fox.Lexing;

namespace Nagisa.Fox
{
    public abstract class LanguageData
    {
        protected readonly List<Pattern> Patterns;
        protected readonly Dictionary<int, string> PatternNames;

        public LanguageData()
        {
            this.Patterns = new List<Pattern>();
            this.PatternNames = new Dictionary<int, string>();
        }

        public abstract List<Pattern> GetPatterns();
        public abstract string GetTokenName(int type);
    }
}