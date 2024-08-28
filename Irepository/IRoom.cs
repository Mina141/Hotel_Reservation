using Hotel_Reservation.Models;
using Hotel_Reservation.ViewModel;

namespace Hotel_Reservation.Irepository
{
    public interface IRoom
    {
        List<Room> GetAll();
        Room GetById(int id);
        void Insert(Room room);
        void Update(int id, Room room);
        void Delete(int id);
        public Room GetRoomFromRoomType(string roomType);
    }
}
