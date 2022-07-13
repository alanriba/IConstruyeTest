using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IConstruye.Dac.Model
{
    [Table("TBL_Product")]
    [Description("Table of the product")]
    public class ProductModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Description("Clave única")]
        public int IdProduct { get; set; }


        [Required]
        [MaxLength(255)]
        [Description("Product Name")]
        public string NameProduct { get; set; }

        [Required]
        [MaxLength(10)]
        [Description("Price of the prodcut")]
        public double PriceProduct { get; set; }

        [Required]
        [MaxLength(10)]
        [Description("Stock of the prodcut")]
        public int StockAvailable { get; set; }
    }
}

