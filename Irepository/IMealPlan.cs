using Hotel_Reservation.Models;

namespace Hotel_Reservation.Irepository
{
    public interface IMealPlan
    {
        List<MealPlan> GetAll();
        MealPlan GetById(int id);
        void Insert(MealPlan mealPlan);
        void Update(int id, MealPlan mealPlan);
        void Delete(int id);
    }
}
