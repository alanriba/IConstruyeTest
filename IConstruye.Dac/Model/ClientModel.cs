using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IConstruye.Dac.Model
{
    [Table("TBL_Client")]
    [Description("Table of the client")]
    public class ClientModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Description("Clave única")]
        public int IdClient { get; set; }


        [Required]
        [MaxLength(255)]
        [Description("Name Client")]
        public string NameClient { get; set; }

        [Required]
        [MaxLength(10)]
        [Description("Email Client")]
        public string EmailClient { get; set; }

        [Required]
        [MaxLength(10)]
        [Description("Direction Client")]
        public string DirectionClient { get; set; }
    }
}

