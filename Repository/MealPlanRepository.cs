using Hotel_Reservation.Irepository;
using Hotel_Reservation.Models;

namespace Hotel_Reservation.Repository
{
    public class MealPlanRepository : IMealPlan
    {
        Hotel_Entity entity;
        public MealPlanRepository(Hotel_Entity entity) 
        {
            this.entity = entity;
        }
        
       

        public List<MealPlan> GetAll()
        {
            return entity.mealPlans.ToList();
        }

        public MealPlan GetById(int id)
        {
            return entity.mealPlans.FirstOrDefault(x => x.Id == id);
        }

        public void Insert(MealPlan mealPlan)
        {
            entity.mealPlans.Add(mealPlan);
            entity.SaveChanges();
        }

        public void Update(int id, MealPlan mealPlan)
        {
            MealPlan meal = GetById(id);
            meal.Name = mealPlan.Name;
            

            entity.SaveChanges();
        }

        public void Delete(int id)
        {
            MealPlan meal = GetById(id);
            entity.mealPlans.Remove(meal);
            entity.SaveChanges();
        }
    }
}
