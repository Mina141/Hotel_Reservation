using Hotel_Reservation.Models;

namespace Hotel_Reservation.Irepository
{
    public interface IRoomType
    {
        List<RoomType> GetAll();
        RoomType GetById(int id);
        void Insert(RoomType roomType);
        void Update(int id, RoomType roomType);
        void Delete(int id);
    }
}
