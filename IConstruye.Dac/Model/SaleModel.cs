using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IConstruye.Dac.Model
{
    [Table("TBL_Sale")]
    [Description("Table of Sale")]
    public class SaleModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Description("Clave única")]
        public int IdSale { get; set; }


        public virtual ProductModel Product { get; set; }
        public virtual ClientModel Client { get; set; }
    }
}

