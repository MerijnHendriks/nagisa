using System;
using System.Collections.Generic;

namespace Nagisa.Core.Execution
{
    public sealed class Environment
    {
        private readonly List<EnvironmentData> _values;

        public Environment()
        {
            this._values = new List<EnvironmentData>();
        }

        public int GetIndex(string name)
        {
            for (int i = 0; i < this._values.Count; i += 1)
            {
                if (this._values[i].Name == name)
                {
                    return i;
                }
            }

            return -1;
        }

        public void DefineMutable(string name, object value)
        {
            EnvironmentData data = new EnvironmentData(name, false, value);
            int index = this.GetIndex(name);

            if (index != -1)
            {
                this._values[index] = data;
            }
            else
            {
                this._values.Add(data);
            }
        }

        public void DefineImmutable(string name, object value)
        {
            EnvironmentData data = new EnvironmentData(name, true, value);
            int index = this.GetIndex(name);

            if (index != -1)
            {
                throw new InvalidOperationException("Overwriting immutable variable " + name);
            }

            this._values.Add(data);
        }

        public object Get(string name)
        {
            int index = this.GetIndex(name);

            if (index != -1)
            {
                return this._values[index].Value;
            }

            throw new InvalidOperationException("Undefined variable " + name);
        }
    }
}