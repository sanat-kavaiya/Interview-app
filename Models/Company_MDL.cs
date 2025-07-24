using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace myApp.Models
{
    public class Company_MDL
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Company_id { get; set; }
        public string Company_name { get; set; }
        public string Company_Adresss { get; set; }
    }
}
