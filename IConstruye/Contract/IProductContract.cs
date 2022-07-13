using IConstruye.Dtos;
using IConstruye.Utils.BusinessValidation.Models.Interfaces;

namespace IConstruye.Contract
{
    public interface IProductContract
    {
        Task<IBusinessResult<IEnumerable<ProductDto>>> GetProduct();
    }
}