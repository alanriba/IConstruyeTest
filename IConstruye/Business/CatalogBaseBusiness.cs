using System;
using IConstruye.Catalogos.Dac.Contracts;
using IConstruye.Utils.BusinessValidation.Models;
using IConstruye.Utils.BusinessValidation.Models.Interfaces;
using static IConstruye.Contract.ICatalogBaseBusiness;

namespace IConstruye.Business
{
    public abstract class CatalogoBusinessBase<Entidad, Dto> : ICatalogBusinessBase<Dto>
    {
        private readonly IReadOnlyDataContract<Entidad> service;

        protected CatalogoBusinessBase(IReadOnlyDataContract<Entidad> service)
        {
            this.service = service;
        }

        public async Task<IBusinessResult<Dto>> Buscar(int id)
        {
            IBusinessResult<Dto> result = new BusinessResult<Dto>();

            result.SetValue(DtoDesdeEntidad(await service.ReadAsync(id)));

            return result;
        }

        public async Task<IBusinessResult<IEnumerable<Dto>>> Listar()
        {
            IBusinessResult<IEnumerable<Dto>> result = new BusinessResult<IEnumerable<Dto>>();

            result.SetValue(DtosDesdeEntidades(await service.ListAsync()));

            return result;
        }

        protected abstract Dto DtoDesdeEntidad(Entidad entidad);

        private IEnumerable<Dto> DtosDesdeEntidades(IEnumerable<Entidad> entidades)
        {
            return entidades.Select(DtoDesdeEntidad);
        }
    }
}
