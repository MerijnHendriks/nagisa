using System;

namespace Lox.Optional
{
    public class Option<T>
        where T : class
    {
        protected readonly T _value;

        protected Option()
        {
            this._value = null;
        }

        public static Option<T> Some(T value)
        {
            return new Some<T>(value);
        }

        public static Option<T> None()
        {
            return new None<T>();
        }

        public static void Match(OptionResult<T> match)
        {
            if (this.GetType() == typeof(Some))
            {
                match(this.value);
            }
        }
    }
}