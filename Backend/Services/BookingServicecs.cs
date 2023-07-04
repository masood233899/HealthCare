using AngularBigBang.Interfaces;
using AngularBigBang.Models;
using AngularBigBang.Models.DTO;

namespace AngularBigBang.Services
{
    public class BookingServicecs: IBookingService
    {
        private readonly IBookIng _bookRepo;
        private readonly ITimeslot _timeslotRepo;


        public BookingServicecs(IBookIng bookRepo, ITimeslot timeslotRepo)
        {
            _bookRepo = bookRepo;
            _timeslotRepo = timeslotRepo;

        }

        public async Task<Booking> Register(Booking book)
        {
            var booked = await _bookRepo.Add(book);
            if (booked != null)
                return booked;
            return null;
        }

        public async Task<List<Booking>> View_All_Booking()
        {
            var booked = await _bookRepo.GetAll();
            if (booked != null)
                return booked;
            return null;
        }

        public async Task<Booking> View_All_BookingById(int id)
        {
            var booked = await _bookRepo.Get(id);
            if (booked != null)
                return booked;
            return null;
        }


        public async Task<List<AvailabilityDTO>> GetUnAvailableDate(DateTime date, int id)
        {
            DateTime targetDate = date;
            int targetTimeslotCount = 4;
            var bookings = await _bookRepo.GetAll();

            var unbookableDates = (from book in bookings
                                   where book.Date > date && book.DoctorId == id
                                   group book by book.Date into g
                                   where g.Select(o => o.TimeId).Distinct().Count() == targetTimeslotCount
                                   select new AvailabilityDTO
                                   {
                                       UnavailableDate = g.Key,
                                       Count = g.Count()
                                   }).ToList();
            return unbookableDates;
        }

        public async Task<List<AvailabilityDTO>> GetAvailableTimeSlot(DateTime date)
        {
            DateTime targetDate = date;

            var bookings = await _bookRepo.GetAll();
            var TimeSlots = await _timeslotRepo.GetAll();
            var unbookableTimeSlots = (from ts in TimeSlots
                                       where !bookings.Any(b => b.TimeId == ts.Id && b.Date == date)
                                       select new AvailabilityDTO
                                       {
                                           UnavailableDate = null,
                                           Count = null,
                                           availableTimeSlot = ts.AddTimeSlot
                                       }).ToList();



            return unbookableTimeSlots;

        }

    }
}
