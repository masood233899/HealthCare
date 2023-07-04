using AngularBigBang.Models;
using AngularBigBang.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace AngularBigBang.Interfaces
{
    public interface IBookingService
    {
        Task<Booking> Register(Booking book);

        Task<List<Booking>> View_All_Booking();

        Task<Booking> View_All_BookingById(int id);

        Task<List<AvailabilityDTO>> GetUnAvailableDate(DateTime date, int id);

        Task<List<AvailabilityDTO>> GetAvailableTimeSlot(DateTime date);
    }
}
