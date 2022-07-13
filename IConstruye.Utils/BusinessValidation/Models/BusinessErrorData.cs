namespace IConstruye.Utils.Models
{
    internal class BusinessErrorData
    {
        public IDictionary<string, object> InputData { get; set; }
        public IEnumerable<string> ErrorMessages { get; set; }
    }
}
