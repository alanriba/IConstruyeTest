
namespace IConstruye.Utils.Models
{
    public class ActionParameter
    {
        public string Name { get; }
        public object Value { get; }

        public ActionParameter(string name, object value)
        {
            Name = name;
            Value = value;
        }
    }
}
