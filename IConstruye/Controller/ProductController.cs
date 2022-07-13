
using IConstruye.Dtos;
using IConstruye.Utils.BusinessValidation.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static IConstruye.Contract.ICatalogBaseBusiness;

namespace IConstruye.Controller
{
    [ApiExplorerSettings(GroupName = "1.0")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : CatalogoControllerBase<ProductDto>
    {
        public ProductController(ICatalogBusinessBase<ProductDto> productBusiness) : base(productBusiness) { }

        /// <summary>
        /// Operación que obtiene un registro de producto
        /// </summary>
        /// <returns>ProductDto</returns>
        public override async Task<ActionResult<IEnumerable<ProductDto>>> Listar()
        {
            return this.BusinessToGetResult(await business.Listar());
        }
    }
}

