


using DataAnnotationsExtensions;
using System.ComponentModel.DataAnnotations;

namespace Hotel_Reservation.ViewModel
{
    public class RoomVM
    {
        [Required]
        [Min(1,ErrorMessage ="The Range is between 1 to 150 ")]
        [Max(150, ErrorMessage = "The Range is between 1 to 150 ")]
        public int Room_Number { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string RoomType_Name { get; set; }
        [Required]
        public bool IsReserved { get; set; }
    }
}
