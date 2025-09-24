namespace Nagisa.Fox.Execution
{
    public sealed class EnvironmentData
    {
        public readonly string Name;
        public readonly bool IsMutable;
        public object Value;

        public EnvironmentData(string name, bool isMutable, object value)
        {
            this.Name = name;
            this.IsMutable = isMutable;
            this.Value = value;
        }
    }
}