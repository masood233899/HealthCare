using AngularBigBang.Models;

namespace AngularBigBang.Interfaces
{
    public interface ITimeslot
    {

/*        Task<TimeSlot> Add(TimeSlot item);
*/       /* Task<TimeSlot> Update(TimeSlot item);
        Task<TimeSlot> Delete(int item);
        Task<TimeSlot> GetValue(int item);*/
        Task<List<TimeSlot>> GetAll();
    }
}
