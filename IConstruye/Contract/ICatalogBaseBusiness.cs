using System;
using IConstruye.Utils.BusinessValidation.Models.Interfaces;

namespace IConstruye.Contract
{
    public class ICatalogBaseBusiness
    {
        public interface ICatalogBusinessBase<T>
        {
            Task<IBusinessResult<IEnumerable<T>>> Listar();
        }
    }
}