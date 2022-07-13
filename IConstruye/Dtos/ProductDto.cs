using System.Diagnostics.CodeAnalysis;

namespace IConstruye.Dtos
{
    [ExcludeFromCodeCoverage]
    public class ProductDto
    {
        public int IdProduct { get; set; }
        public string NameProduct { get; set; }
        public double PriceProduct { get; set; }
        public int StockAvailable { get; set; }
    }
}
