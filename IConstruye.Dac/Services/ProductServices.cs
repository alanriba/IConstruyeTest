using System;
using IConstruye.Dac.Model;
using IConstruye.Dac.Providers;

namespace IConstruye.Dac.Services
{
    public class ProductServices
    {
        private readonly CatalogosContext catalogosContext;

        public ProductServices(CatalogosContext catalogosContext)
        {
            this.catalogosContext = catalogosContext;
        }

        public async Task<ProductModel> ReadAsync()
        {
            return await catalogosContext.ProductModel.FindAsync();
        }
    }
}

