using AngularBigbang.Exeptions;
using AngularBigBang.Interfaces;
using AngularBigBang.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace AngularBigBang.Services
{
    public class BookingRepo: IBookIng
    {
        private readonly AngularBigBangContext _context;

        public BookingRepo(AngularBigBangContext context)
        {
            _context = context;
        }

        public async Task<Booking> Add(Booking book)
        {
            try
            {
                var booked = _context.Bookings.FirstOrDefault(h => h.Id == book.Id);
                if (booked == null)
                {
                    await _context.Bookings.AddAsync(book);
                    await _context.SaveChangesAsync();
                    return book;
                }

                return null;
            }
            catch (SqlException se)
            {
                throw new InvalidSqlException(se.Message);
            }
        }

        public async Task<List<Booking>?> GetAll()
        {
            try
            {
                var booked = await _context.Bookings.ToListAsync();
                if (booked != null)
                    return booked;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }

        public async Task<Booking> Get(int id)
        {
            try
            {
                var books = await _context.Bookings.ToListAsync();
                var booked = books.SingleOrDefault(h => h.Id == id);
                if (booked != null)
                    return booked;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }

    }
}
