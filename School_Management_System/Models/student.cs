using System.ComponentModel.DataAnnotations;

namespace School_Management_System.Models
{
    public class student
    {
        [Display (Name ="Student Id")]
        public int Id { get; set; }
        [Display (Name ="Student Name")]
        public string name { get; set; }
        [Display(Name ="Address")]
        public string address { get; set; }
        [Display (Name ="Roll")]
        public int roll { get; set; }
        [Display (Name="Class")]
        public string clas { get; set; }

    }
}
