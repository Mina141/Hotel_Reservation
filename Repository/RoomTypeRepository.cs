using Hotel_Reservation.Irepository;
using Hotel_Reservation.Models;

namespace Hotel_Reservation.Repository
{
    public class RoomTypeRepository : IRoomType
    {
        Hotel_Entity entity;
        public RoomTypeRepository(Hotel_Entity entity ) 
        { 
            this.entity = entity;
        }
        

        public List<RoomType> GetAll()
        {
            return entity.roomTypes.ToList();

        }

        public RoomType GetById(int id)
        {
            return entity.roomTypes.FirstOrDefault(x => x.Id == id);
        }

        public void Insert(RoomType roomType)
        {
            entity.roomTypes.Add(roomType);
            entity.SaveChanges();
        }

        public void Update(int id, RoomType roomType)
        {
            RoomType oldType = GetById(id);
            
            oldType.Type_Name = roomType.Type_Name;
            oldType.RoomPrice = roomType.RoomPrice;

            entity.SaveChanges();
        }

        public void Delete(int id)
        {
            RoomType oldType = GetById(id);

            entity.roomTypes.Remove(oldType);
            entity.SaveChanges();
        }
    }
}
