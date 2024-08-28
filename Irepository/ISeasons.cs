using Hotel_Reservation.Models;

namespace Hotel_Reservation.Irepository
{
    public interface ISeasons
    {
        List<Seasons> GetAll();
        Seasons GetById(int id);
        void Insert(Seasons Season);
        void Update(int id, Seasons season);
        void Delete(int id);
    }
}
