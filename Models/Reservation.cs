using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel_Reservation.Models
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }
        public int Nights_Number { get; set; }
        public bool IsReserved { get; set; }
        public string Customer_Name { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public int Adults_Number { get; set; }
        public int Children_Number { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        [ForeignKey("Room")]
        public int Room_Id { get; set; }
        [ForeignKey("MealPlansRate")]
        public int MealPlanRate_Id { get; set; }
        
        public int? TotalCost { get; set; } 
        public virtual Room Room { get; set; }
        public virtual  MealPlansRate MealPlansRate { get; set; }
        

    }
}
