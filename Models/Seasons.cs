using System.ComponentModel.DataAnnotations;

namespace Hotel_Reservation.Models
{
    public class Seasons
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }


    }
}
