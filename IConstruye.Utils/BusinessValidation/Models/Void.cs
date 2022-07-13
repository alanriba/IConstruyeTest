using System.Diagnostics.CodeAnalysis;

namespace IConstruye.Utils.BusinessValidation.Models
{
    [ExcludeFromCodeCoverage]
    public sealed class Void
    {
        private Void()
        {
            throw new InvalidOperationException("No se puede instanciar un objeto Void");
        }
    }
}
