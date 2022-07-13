using IConstruye.Api.Model;
using IConstruye.Utils.BusinessValidation.Models.Interfaces;

namespace IConstruye.Contract
{
    public interface ISaleContract
    {
        Task<IBusinessResult<bool>> SaleIssuence(SaleRequest dto, ControllerData controllerData);
    }
}


