using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PROIECT_MEDII.Models
{
    public class Festival
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string FestivalCategory { get; set; }

        //Relationships
        public ICollection<Artist_Festival>? Artists_Festivals { get; set; }

        //Location
        public int? LocationId { get; set; }
        public Location? Location { get; set; }

        //Producer
        public int? ProducerId { get; set; }
        public Producer? Producer { get; set; }
    }
}
