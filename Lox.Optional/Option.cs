namespace Lox.Optional
{
    public class Option<T>
        where T : class
    {
        private readonly T _content;

        private Option()
        {
            this._content = null;
        }

        private Option(T content)
        {
            this._content = content;
        }

        public static Option<T> Some(T content)
        {
            return new Option<T>(content);
        }

        public static Option<T> None()
        {
            return new Option<T>();
        }

        public Option<TResult> Map<TResult>(OptionMap<T, TResult> map)
            where TResult : class
        {
            if (this._content != null)
            {
                return Option<TResult>.Some(map(this._content));
            }

            return Option<TResult>.None();
        }

        public T Reduce(T else)
        {
            if (this._content != null)
            {
                return this._content;
            }

            return else;
        }
    }
}