using AngularBigbang.Models.DTO;
using AngularBigBang.Models;
using AngularBigBang.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace AngularBigBang.Interfaces
{
    public interface IDoctorService
    {
        Task<UserDTO> Register(Doctor doctorRegisterDTO);

        Task<DoctorDTO?> staffRegister(DoctorDTO doctorRegisterDTO);

        Task<List<DoctorDTO>> View_All_StaffRequest();
        Task<DoctorDTO?> deletestaffinlist(DoctorDTO doctorRegisterDTO);

        Task<List<Doctor>> View_All_doctors();
        Task<Doctor> getDoctorByName(string name);

        Task<List<Doctor>> filterByDept(string dept);
    }
}
