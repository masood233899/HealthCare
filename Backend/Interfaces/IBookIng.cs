using AngularBigbang.Models.DTO;
using AngularBigBang.Models;

namespace AngularBigBang.Interfaces
{
    public interface IBookIng
    {
        Task<Booking> Add(Booking book);

        Task<Booking> Get(int id);
        Task<List<Booking>?> GetAll();

    }
}
