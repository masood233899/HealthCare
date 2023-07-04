using AngularBigBang.Models;
using Microsoft.AspNetCore.Mvc;

namespace AngularBigBang.Interfaces
{
    public interface ITimeslotService
    {

        Task<List<TimeSlot>> View_All_TimeSlots();
    }
}
