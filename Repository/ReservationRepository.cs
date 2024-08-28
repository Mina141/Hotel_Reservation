using Hotel_Reservation.Irepository;
using Hotel_Reservation.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Hotel_Reservation.Repository
{
    public class ReservationRepository : IReservation
    {
        Hotel_Entity entity;
        public ReservationRepository(Hotel_Entity entity) 
        {
            this.entity = entity;
        }
      

        public List<Reservation> GetAll()
        {
            return entity.reservation.Include(x=>x.MealPlansRate).Include(x=>x.Room).ToList();
        }


        public Reservation GetById(int id)
        {
            return entity.reservation.Include(x => x.Room).Include(x => x.MealPlansRate).
                FirstOrDefault(x => x.Id == id);
        }

       public void Insert(Reservation reservation)        
        {
            //int numofroom= entity.reservation.Sum(x=>x.Room_Number).Count();
            
            reservation.CheckIn = DateTime.Now;
            //reservation.CheckOut = DateTime.Now.AddDays(reservation.Night_Number);
            
            entity.reservation.Add(reservation);
            entity.SaveChanges();
        }

        public void Update(int id, Reservation reservation)
        {
            Reservation OldReservation = GetById(id);
            OldReservation.Customer_Name = reservation.Customer_Name;
            OldReservation.Country = reservation.Country;
            OldReservation.Email = reservation.Email;
            OldReservation.Adults_Number = reservation.Adults_Number;
            OldReservation.Children_Number = reservation.Children_Number;
            //OldReservation.CheckIn = reservation.CheckIn;
           // reservation.CheckOut = DateTime.Now.AddDays(reservation.Night_Number);
            //OldReservation.MealPlan_Id = reservation.MealPlan_Id;
            //OldReservation.RoomType_Id = reservation.RoomType_Id;
            //OldReservation.Room_Number= reservation.Room_Number;

        }
        public Seasons CurrentSeason (DateTime CheckIn)
        {
            //Reservation reservation = GetById(id);
                        
            return entity.seasons.Where(x=>x.Start >= CheckIn && x.End <CheckIn).FirstOrDefault();
    
        }
        public double TotalCost(int NumGuests,int numDays,int mealplanRateId , int roomId)
        {
            var meal = entity.MealPlansRates.Where(x=>x.id== mealplanRateId).FirstOrDefault();
            var room = entity.Rooms.Include(x=>x.RoomType).FirstOrDefault(x=>x.Id == roomId);
            var totalCost = NumGuests * numDays * meal.Price + numDays * room.RoomType.RoomPrice; 
            return totalCost;
        }

        public void HandleReservation(Reservation reservation)
        {
            Seasons season = CurrentSeason(reservation.CheckIn);
            Room room = entity.Rooms.Where(x => x.Id == reservation.Room_Id).FirstOrDefault();
            room.IsReserved = true;
            entity.SaveChanges();
            
            var MealPlanRate = entity.MealPlansRates.Where(x=>x.MealPlan_Id==reservation.MealPlanRate_Id 
            && x.Seasons_Id==season.Id).FirstOrDefault();

            var MealPrice = MealPlanRate.Price;
            
            var diff = reservation.CheckOut - reservation.CheckIn;
            var NumOfDays = diff.Days;
            var NumberOfGusts = reservation.Adults_Number + reservation.Children_Number;


            var Total_Cost =
                TotalCost(NumberOfGusts, NumOfDays, MealPlanRate.id, reservation.Room_Id);
        }
        public void Delete(int id)
        {
            Reservation reservation = GetById(id);
            entity.reservation.Remove(reservation);
            entity.SaveChanges();
        }
    }
}
