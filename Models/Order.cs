using PROIECT_MEDII.Models;
using System.Diagnostics.Metrics;

namespace Proiect_Medii.Models
{
    public class Order
    {
        public int ID { get; set; }
        public int? UserID { get; set; }
   
        public User? User { get; set; }
        public int? FestivalID { get; set; }
        public Festival? Festival { get; set; }

    }
}
