using System.Collections.Generic;
using Nagisa.Fox.Execution;
using Nagisa.Fox.Lexing;

namespace Nagisa.Fox
{
    public abstract class LanguageData
    {
        protected readonly List<Pattern> Patterns;
        protected readonly Dictionary<int, string> PatternNames;
        protected readonly Environment Globals;

        public LanguageData()
        {
            this.Patterns = new List<Pattern>();
            this.PatternNames = new Dictionary<int, string>();
            this.Globals = new Environment(null);
        }

        public abstract List<Pattern> GetPatterns();
        public abstract string GetTokenName(int type);
        public abstract Environment GetGlobals();
    }
}