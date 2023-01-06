using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PROIECT_MEDII.Models
{
    public class Producer
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Profile Picture")]
        [Required(ErrorMessage = "Profile Picture is required")]
        public string ProfilePictureURL { get; set; }

        [Display(Name = "Producer Full Name")]
        [Required(ErrorMessage = "Full Name is required")]
       public string FullName { get; set; }

        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Biography is required")]
        public string Bio { get; set; }
        //Relationships
        public ICollection<Festival>? Festivals { get; set; }
    }
}
