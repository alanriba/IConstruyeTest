using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using IConstruye.Api.Model;
using IConstruye.Contract;
using IConstruye.Dtos;
using IConstruye.Utils.BusinessValidation.Extensions;
using IConstruye.Utils.BusinessValidation.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IConstruye.Controller
{
    [ApiExplorerSettings(GroupName = "1.0")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {

        private readonly ISaleContract saleBusiness;

        public SaleController(ISaleContract saleBusiness)
        {
            this.saleBusiness = saleBusiness;
        }

        #region [Generar vents]
        /// <summary>
        /// </summary>
        /// <returns>Generacion venta exitosa 200 OK, 404 Not Found datos no encontrados, 400 BadRequest o 500 error interno.</returns>
        /// <response code="200">Respuesta exitosa para la venta.</response>
        /// <response code="400">Petición del servicio erronea.</response>
        /// <response code="404">No se encontro el servicio para venta</response>
        /// <response code="500">Error interno.</response>
        /// 
        [ApiVersion("1.0")]
        [HttpPost("sale")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<bool>> SaleGeneration([FromBody] SaleRequest dto)
        {

            ControllerData controllerData = new ControllerData()
            {
                ControllerName = ControllerContext.RouteData.Values["controller"].ToString(),
                ControllerActionName = ControllerContext.RouteData.Values["action"].ToString(),
            };
            IBusinessResult<bool> sale = await saleBusiness.SaleIssuence(dto, controllerData);

            return this.BusinessToCreateResult(sale);
        }
        #endregion
    }
}

