using AngularBigBang.Interfaces;
using AngularBigBang.Models;

namespace AngularBigBang.Services
{
    public class TimeslotService: ITimeslotService
    {
        private readonly ITimeslot _timeslotRepo;

        public TimeslotService(ITimeslot timeslotRepo)
        {
            _timeslotRepo = timeslotRepo;

        }


        public async Task<List<TimeSlot>> View_All_TimeSlots()
        {
            var slots = await _timeslotRepo.GetAll();
            if (slots != null)
                return slots;
            return null;
        }

    }
}
