using System;
using IConstruye.Dtos;

namespace IConstruye.Api.Model
{
    public class SaleRequest
    {
        /// <summary>
        /// Id Producto
        /// </summary>
        public int IdProduct { get; set; }
        /// <summary>
        /// Informacion del cliente
        /// </summary>
        public ClientDto clientDto { get; set; }
        
    }
}

