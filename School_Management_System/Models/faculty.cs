using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace School_Management_System.Models
{
    public class faculty
    {
        [Display(Name = "Faculty Id")]
        public int Id { get; set; }
        [Display(Name = "Faculty Name")]
        public string name { get; set; }
        [Display(Name = "Address")]
        public string address { get; set; }
        [Display(Name = "Department")]
        public string department { get; set; }
        [Display(Name = "Salary")]
        public double salary { get; set; }
        [Display(Name = "Mobile NO")]
        public string mobile { get; set; }
    }
}
