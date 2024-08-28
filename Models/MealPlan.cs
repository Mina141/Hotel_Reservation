using System.ComponentModel.DataAnnotations;

namespace Hotel_Reservation.Models
{
    public class MealPlan
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
