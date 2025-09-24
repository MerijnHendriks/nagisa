using System;
using System.Collections.Generic;

namespace Nagisa.Lox.Execution
{
    public sealed class Environment
    {
        private readonly Environment _enclosing;
        private readonly List<EnvironmentData> _values;

        public Environment(Environment enclosing)
        {
            this._enclosing = enclosing;
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

        public void Define(string name, bool isMutable, object value)
        {
            EnvironmentData data = new EnvironmentData(name, isMutable, value);
            int index = this.GetIndex(name);

            if (index != -1)
            {
                this._values[index] = data;
                throw new InvalidOperationException("Variable already exists: " + name);
            }
            else
            {
                this._values.Add(data);
            }
        }

        public object Get(string name)
        {

            int index = this.GetIndex(name);

            if (index != -1)
            {
                return this._values[index].Value;
            }

            if (_enclosing != null)
            {
                return this._enclosing.Get(name);
            }

            throw new InvalidOperationException("Undefined variable: " + name);
        }

        public void Set(string name, object value)
        {
            int index = this.GetIndex(name);

            if (index != -1)
            {
                if (this._values[index].IsMutable == false)
                {
                    throw new InvalidOperationException("Assignment to immutable variable: " + name);
                }

                this._values[index].Value = value;
                return;
            }

            if (_enclosing != null)
            {
                this._enclosing.Set(name, value);
                return;
            }

            throw new InvalidOperationException("Undefined variable: " + name);
        }
    }
}