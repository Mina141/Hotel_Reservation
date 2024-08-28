using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel_Reservation.Models
{
    public class Room
    {
        [Key]
        public int Id { get; set; }
        public int Room_Number { get; set; }
        [ForeignKey("RoomType")]
        public int RoomType_Id { get; set; }
        public bool IsReserved { get; set; }
        
        public virtual RoomType RoomType { get; set; }

    }
}
