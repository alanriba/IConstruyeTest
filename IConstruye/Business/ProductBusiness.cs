using IConstruye.Catalogos.Dac.Contracts;
using IConstruye.Dac.Model;
using IConstruye.Dtos;

namespace IConstruye.Business
{
    public class ProductBusiness: CatalogoBusinessBase<ProductModel, ProductDto>
    {
        public ProductBusiness(IReadOnlyDataContract<ProductModel> service)
           : base(service) { }

        protected override ProductDto DtoDesdeEntidad(ProductModel entidad)
        {
            return new ProductDto()
            {
                IdProduct = entidad.IdProduct,
                NameProduct = entidad.NameProduct,
                PriceProduct = entidad.PriceProduct,
                StockAvailable = entidad.StockAvailable
            };
        }   
    }
}
