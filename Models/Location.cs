using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PROIECT_MEDII.Models
{
    public class Location
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Location Logo")]
        [Required(ErrorMessage = "Location logo is required")]
        public string Logo { get; set; }

        [Display(Name = "Location Name")]
        [Required(ErrorMessage = "Location name is required")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Locationa description is required")]
        public string Description { get; set; }

        //Relationships
        public ICollection<Festival>? Festivals { get; set; }
    }
}
