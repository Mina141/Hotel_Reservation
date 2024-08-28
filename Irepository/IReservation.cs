using Hotel_Reservation.Models;

namespace Hotel_Reservation.Irepository
{
    public interface IReservation
    {
        List<Reservation> GetAll();
        Reservation GetById(int id);
        void Insert(Reservation reservation);
        void Update(int id, Reservation reservation);
        void Delete(int id);
    }
}
