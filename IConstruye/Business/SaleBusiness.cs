using System;
using IConstruye.Api.Model;
using IConstruye.Contract;
using IConstruye.Dac.Contracts;
using IConstruye.Dac.Model;
using IConstruye.Utils.BusinessValidation.Models;
using IConstruye.Utils.BusinessValidation.Models.Interfaces;
using IConstruye.Utils.Enums;
using IConstruye.Utils.Models;

namespace IConstruye.Api.Business
{
    public class SaleBusiness: ISaleContract
    {
        private readonly IWriteOnlyDataContract<SaleModel> saleService;

        public SaleBusiness(IWriteOnlyDataContract<SaleModel> saleService)
        {
            this.saleService = saleService;
        }

        Task<IBusinessResult<bool>> ISaleContract.SaleIssuence(SaleRequest dto, ControllerData controllerData)
        {
            IBusinessResult<bool> resultadoEmision = new BusinessResult<bool>();

            //sale entityPolicyChannel = await SavePolicyChannel(dto);

            return (Task<IBusinessResult<bool>>)resultadoEmision;
        }

        private BusinessErrorsDetails GenerarDetallesLogNegocio(int idIssuenceChannel, ControllerData controllerData, params ActionParameter[] actionParameter)
        {
            return new BusinessErrorsDetails()
            {
                InputData = actionParameter,
                TipoServicio = TipoServicio.GuardarProducto,
                ControllerName = controllerData.ControllerName,
                ActionName = controllerData.ControllerActionName
            };
        }

        private async Task<SaleModel> SavePolicyChannel(SaleRequest requestCanal)
        {
            ProductModel product = new ProductModel
            {
                IdProduct = requestCanal.IdProduct
            };

            ClientModel client = new ClientModel
            {
                NameClient = requestCanal.clientDto.NameClient,
                DirectionClient = requestCanal.clientDto.DirectionClient,
                EmailClient = requestCanal.clientDto.EmailClient
            };

            SaleModel sale = new SaleModel
            {
               Product = product,
               Client = client
            };

            sale = await saleService.CreateAsync(sale);

            return sale;
        }
    }
}

