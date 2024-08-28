using DataAnnotationsExtensions;
using System.ComponentModel.DataAnnotations;

namespace Hotel_Reservation.ViewModel
{
    public class ReservationVM
    {
        [Required]
        [DataType(DataType.Text)]
        public string Customer_Name { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Country { get; set; }
        [Required]
        [Min(1,ErrorMessage ="Single or double only")]
        [Max(2,ErrorMessage ="Single or double only")]
        public int Adults_Number { get; set; }
        [Required]
        [Min(0,ErrorMessage ="Only 0 to 2 children allowed")]
        [Max(2,ErrorMessage = "Only 0 to 2 children allowed")]
        public int Children_Number { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CheckIn { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CheckOut { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public int Room_Type_Name { get; set; }
        [Required]
        [Min(1, ErrorMessage = "The Range is between 1 to 150 ")]
        [Max(150, ErrorMessage = "The Range is between 1 to 150 ")]
        public int Room_Number { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string MealPlan_Type { get; set; }
        [Required]
        public bool Is_Reserved { get; set; }

    }
}
