namespace PROIECT_MEDII.Models
{
    public class Artist_Festival
    {
        public int Id { get; set; }
        public int? FestivalId { get; set; }
        public Festival? Festival { get; set; }

        public int? ArtistId { get; set; }
        public Artist? Artist { get; set; }
    }
}
