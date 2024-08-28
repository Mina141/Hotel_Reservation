using Hotel_Reservation.Irepository;
using Hotel_Reservation.Models;
using Hotel_Reservation.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Reservation.Repository
{
    public class RoomRepository : IRoom
    {
        Hotel_Entity entity;
        public RoomRepository(Hotel_Entity entity ) 
        { 
            this.entity = entity;
        }
       

        public List<Room> GetAll()
        {
            return entity.Rooms.Include(x=>x.RoomType).ToList();
        }

        public Room GetById(int id)
        {
            return entity.Rooms.Include(x => x.RoomType).FirstOrDefault(x => x.Id == id);
        }

        public void Insert(Room room)
        {
            room.Room_Number++;
            room.IsReserved = false;
            entity.Rooms.Add(room);
            entity.SaveChanges();
        }

        public void Update(int id, Room room)
        {
            Room OldRoom = GetById(id);
            OldRoom.Room_Number = room.Room_Number;
            OldRoom.IsReserved = room.IsReserved;
            OldRoom.RoomType_Id = room.RoomType_Id;
            
            entity.SaveChanges();
        }

        public void Delete(int id)
        {
            Room room = GetById(id);
            entity.Rooms.Remove(room);
            entity.SaveChanges();
        }

        public Room GetRoomFromRoomType(string roomType)
        {
            RoomType room = entity.roomTypes.FirstOrDefault(x => x.Type_Name == roomType);
            return entity.Rooms.FirstOrDefault(x => x.RoomType_Id == room.Id);
        }

        
    }
}
