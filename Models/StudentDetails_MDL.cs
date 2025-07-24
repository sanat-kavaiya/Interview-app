using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace myApp.Models
{
    public class StudentDetails_MDL
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int StudentId { get; set; }
        [ForeignKey("Company")]
        public int Company_id { get; set; }

        [ForeignKey("Employee")]
        public int EmpId { get; set; }
        public string StudentName { get; set; }
        public string Password { get; set; }

        public virtual Company_MDL Company { get; set; }
        public virtual Employee_MDL Employee { get; set; }
    }
}
