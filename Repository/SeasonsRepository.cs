using Hotel_Reservation.Irepository;
using Hotel_Reservation.Models;

namespace Hotel_Reservation.Repository
{
    public class SeasonsRepository : ISeasons
    {
        Hotel_Entity entity;
        public SeasonsRepository(Hotel_Entity entity ) 
        { 
            this.entity = entity;
        }

       

        public List<Seasons> GetAll()
        {
            return entity.seasons.ToList();
        }

        public Seasons GetById(int id)
        {
            return entity.seasons.FirstOrDefault(x=>x.Id==id);
        }

        public void Insert(Seasons Season)
        {
            entity.seasons.Add(Season);
            
            entity.SaveChanges();
        }

        public void Update(int id, Seasons season)
        {
            Seasons oldSeason = GetById(id);
            oldSeason.Name = season.Name;
            oldSeason.Start = season.Start;
            oldSeason.End = season.End;
            
            entity.SaveChanges();

        }

        public void Delete(int id)
        {
            Seasons Season = GetById(id);
            
            entity.seasons.Remove(Season);
            entity.SaveChanges();
        }
    }
}
