using System.ComponentModel.DataAnnotations;

namespace Hotel_Reservation.Models
{
    public class RoomType
    {
        [Key]
        public int Id { get; set; }
        public string Type_Name { get; set; }
        public double RoomPrice { get; set; }
        public virtual List<Room> Rooms { get; set; }
    }
}
