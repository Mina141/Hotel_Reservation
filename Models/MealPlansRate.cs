using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel_Reservation.Models
{
    public class MealPlansRate
    {
        [Key]
        public int id { get; set; }
        [ForeignKey("MealPlan")]
        public int MealPlan_Id { get; set; }
        [ForeignKey("Seasons")]
        public int Seasons_Id { get; set; }
        public double Price { get; set; }

        public virtual Seasons Seasons { get; set; }
        public virtual MealPlan MealPlan { get; set; }
    }
}
