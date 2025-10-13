using System.Collections.Generic;
using Nagisa.Fox.Execution;
using Nagisa.Fox.Lexing;

namespace Nagisa.Fox
{
    public abstract class LanguageData
    {
        protected readonly List<Pattern> Patterns;
        protected readonly Dictionary<int, string> PatternNames;
        public Env StdEnv;

        public LanguageData()
        {
            this.Patterns = new List<Pattern>();
            this.PatternNames = new Dictionary<int, string>();
            this.StdEnv = null;
        }

        public abstract List<Pattern> GetPatterns();
        public abstract string GetTokenName(int type);

        public void SetStdEnv(Env env)
        {
            this.StdEnv = env;
        }
    }
}