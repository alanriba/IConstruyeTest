using System.Net.Http.Headers;

namespace IConstruye.Utils.BusinessValidation.Models.Interfaces
{
    public interface IFileData
    {
        string FileName { get; set; }
        Stream FileStream { get; set; }
        MediaTypeHeaderValue ContentType { get; set; }
    }
}
