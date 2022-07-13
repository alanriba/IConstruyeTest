using Microsoft.AspNetCore.Mvc;
using IConstruye.Utils.BusinessValidation.Models.Interfaces;
using IConstruye.Utils.BusinessValidation.Models;
using System.Net;
using System.Diagnostics.CodeAnalysis;

namespace IConstruye.Utils.BusinessValidation.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class ControllerBaseExtensions
    {
        /// <summary>
        /// Transforma un resultado de negocio en una respuesta GET.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="controllerBase"></param>
        /// <param name="businessResult"></param>
        /// <returns></returns>
        public static ActionResult<T> BusinessToGetResult<T>(this ControllerBase controllerBase, IBusinessResult<T> businessResult)
        {
            if (!businessResult.IsValid())
            {
                return controllerBase.BadRequestWithBusinessErrors(businessResult);
            }
            if (!businessResult.HasValue())
            {
                return controllerBase.NotFound();
            }
            return controllerBase.Ok(businessResult.Value());
        }

 
        /// <summary>
        /// Transforma una resultado de negocio en una respuesta cuando creamos un recurso. Típicamente utilizado durante operaciones POST o PUT de creación.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="controllerBase"></param>
        /// <param name="businessResult"></param>
        /// <returns></returns>
        public static ActionResult<T> BusinessToCreateResult<T>(this ControllerBase controllerBase, IBusinessResult<T> businessResult)
        {
            if (!businessResult.IsValid())
            {
                return controllerBase.BadRequestWithBusinessErrors(businessResult);
            }
            if (!businessResult.HasValue())
            {
                throw new InvalidOperationException("Una operación de creación debe retonar el recurso creado.");
            }
            //No se ocupa CreatedAtAction para no forzar la inclusión de una Uri del nuevo recurso 
            return controllerBase.StatusCode((int)HttpStatusCode.Created, businessResult.Value());
        }

        /// <summary>
        /// Transforma un resultado de negocio en una respuesta de actualización. Usado con PATCH y PUT de actualización que
        /// retorna el valor actualizado.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="controllerBase"></param>
        /// <param name="businessResult">Este resultado debe tener un valor</param>
        /// <returns></returns>
        public static ActionResult<T> BusinessToUpdateResult<T>(this ControllerBase controllerBase, IBusinessResult<T> businessResult)
        {
            if (!businessResult.IsValid())
            {
                return controllerBase.BadRequestWithBusinessErrors(businessResult);
            }
            if (!businessResult.HasValue())
            {
                throw new InvalidOperationException("Se debe incluir el contenido actualizado.");
            }
            return controllerBase.Ok(businessResult.Value());
        }

  
        /// <summary>
        /// Genera una respuesta de error a partir de un resultado inválido
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="controllerBase"></param>
        /// <param name="businessResult">Respuesta de negocio que posee un estado inválido</param>
        /// <see cref="SimpleErrorResponse"/>
        /// <returns>Returna Bad Request con un objeto de error simple</returns>
        public static BadRequestObjectResult BadRequestWithBusinessErrors<T>(this ControllerBase controllerBase, IBusinessResult<T> businessResult)
        {
            if (businessResult == null)
            {
                throw new ArgumentNullException("businessResult");
            }
            if (businessResult.IsValid())
            {
                throw new ArgumentException("El resultado tiene un estado válido, no se puede crear una respuesta erronea de un resultado correcto.", "businessResult");
            }
            SimpleErrorResponse response = new SimpleErrorResponse();
            response.Status = (int)HttpStatusCode.BadRequest;
            response.Message = "Errores de negocio encontrados";
            response.ValidationErrors = businessResult.Errors();
            return controllerBase.BadRequest(response);
        }
    }
}
