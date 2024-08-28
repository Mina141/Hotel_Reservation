using Microsoft.EntityFrameworkCore;

namespace Hotel_Reservation.Models
{
    public class Hotel_Entity:DbContext
    {

        public Hotel_Entity(DbContextOptions options):base(options) 
        { }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomType> roomTypes { get; set; }
        public DbSet<Seasons> seasons { get; set; }
        public DbSet<MealPlan> mealPlans { get; set; }
        public DbSet<MealPlansRate> MealPlansRates{ get; set; }
        public DbSet<Reservation> reservation { get; set; }

    }
}
