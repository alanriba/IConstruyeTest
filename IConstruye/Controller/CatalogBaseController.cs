using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using static IConstruye.Contract.ICatalogBaseBusiness;

namespace IConstruye.Controller
{
  
        /// <summary>
        /// Controlador base que permite generar una búsqueda de registros del catálogo
        /// </summary>
        /// <typeparam name="Dto">Objeto a filtrar</typeparam>
        public abstract class CatalogoControllerBase<Dto> : ControllerBase
        {
            protected readonly ICatalogBusinessBase<Dto> business;

            protected CatalogoControllerBase(ICatalogBusinessBase<Dto> business)
            {
                this.business = business;
            }

            /// <summary>
            /// Operación que trae la lista completa de registros del catálogo de <typeparamref name="Dto"/>
            /// </summary>
            /// <returns></returns>
            [ApiVersion("1.0")]
            [HttpGet]
            [ProducesResponseType((int)HttpStatusCode.OK)]
            [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
            public abstract Task<ActionResult<IEnumerable<Dto>>> Listar();
    }
    }
