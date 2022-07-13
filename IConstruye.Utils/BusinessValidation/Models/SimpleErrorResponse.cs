using System.Diagnostics.CodeAnalysis;

namespace IConstruye.Utils.BusinessValidation.Models
{
    [ExcludeFromCodeCoverage]
    public class SimpleErrorResponse
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public IEnumerable<string> ValidationErrors { get; set; }
    }
}
