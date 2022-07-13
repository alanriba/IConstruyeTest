using System.Diagnostics.CodeAnalysis;

namespace IConstruye.Utils.Swagger
{
    [ExcludeFromCodeCoverage]
    internal class SwaggerVersionConfiguration
    {
        public string Version { get; set; }
        public string EndpointUrl { get; set; }
        public string EndpointDescription { get; set; }
    }
}
