using System.Diagnostics.CodeAnalysis;

namespace IConstruye.Dtos
{
    [ExcludeFromCodeCoverage]
    public class ClientDto
    {
        public int IdClient { get; set; }
        public string NameClient { get; set; }
        public string EmailClient { get; set; }
        public string DirectionClient { get; set; }
    }
}
