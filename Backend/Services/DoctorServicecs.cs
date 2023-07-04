using AngularBigbang.Interfaces;
using AngularBigbang.Models.DTO;
using AngularBigbang.Services;
using AngularBigBang.Interfaces;
using AngularBigBang.Models;
using AngularBigBang.Models.DTO;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;

namespace AngularBigBang.Services
{
    public class DoctorServicecs : IDoctorService
    {
        private readonly IDoctor _doctorRepo;
        private readonly ITokenGenerate _tokenService;
        private static List<DoctorDTO> staffList = new List<DoctorDTO>();

        public DoctorServicecs(IDoctor doctorRepo, ITokenGenerate tokenService)
        {
            _doctorRepo = doctorRepo;
            _tokenService = tokenService;

        }

        public async Task<UserDTO> Register(Doctor doctorRegisterDTO)
        {
            UserDTO user = null;
            DoctorDTO userToDelete = staffList.Find(user => user.UserName == doctorRegisterDTO.UserName);
            if (userToDelete != null)
            {
                // Remove the object from the list
                staffList.Remove(userToDelete);
            }
            using (var hmac = new HMACSHA512())
            {
                
                var resultUser = await _doctorRepo.Add(doctorRegisterDTO);
                if (resultUser != null)
                {
                    user = new UserDTO();
                    user.UserName = resultUser.UserName;
                    user.Role = resultUser.Role;
/*                    user.Token = _tokenService.GenerateToken(user);
*/                }
            }
            return user;

        }

        public async Task<DoctorDTO?> staffRegister(DoctorDTO doctorRegisterDTO)
        {
            var users = await _doctorRepo.GetAll();
            var newstaff = users.SingleOrDefault(u => u.UserName == doctorRegisterDTO.UserName);
            var desiredUser = staffList.SingleOrDefault(u => u.UserName == doctorRegisterDTO.UserName);
            if (newstaff == null && desiredUser == null)
            {

                /* UserRegisterDTO user1 = new UserRegisterDTO();
                 user1.Name = userRegisterDTO.Name;
                 user1.EmailId = userRegisterDTO.EmailId;
                 user1.UserName = userRegisterDTO.UserName;
                 user1.PhoneNumber = userRegisterDTO.PhoneNumber;
                 user1.Address = userRegisterDTO.Address;
                 user1.Role = userRegisterDTO.Role;
                 user1.UserPassword = userRegisterDTO.UserPassword;*/

                staffList.Add(doctorRegisterDTO);
                /*                  staffDTO.get(staffDTO);
                */




                return doctorRegisterDTO;
            }


            return null;

        }

        public async Task<DoctorDTO?> deletestaffinlist(DoctorDTO doctorRegisterDTO)
        {
            var userToDelete = staffList.Find(user => user.UserName == doctorRegisterDTO.UserName);
            if (userToDelete != null)
            {
                // Remove the object from the list
                staffList.Remove(doctorRegisterDTO);
                return doctorRegisterDTO;
            }
            return null;
        }

        public async Task<List<DoctorDTO>> View_All_StaffRequest()
        {
            /*var obj = staffDTO.GetStaffList();
            List<UserRegisterDTO> retrievedList = obj.staffList;
            if (retrievedList == null)
            {
                return null;
            }
            return retrievedList;*/

            if (staffList == null)
            {
                return null;
            }
            return staffList;


        }

        public async Task<List<Doctor>> View_All_doctors()
        {
            var doctors = await _doctorRepo.GetAll();
            if (doctors != null)
                return doctors;
            return null;
        }

        public async Task<Doctor> getDoctorByName(string name)
        {
            var doctor = await _doctorRepo.Get(name);
            if (doctor != null)
                return doctor;
            return null;
        }

        public async Task<List<Doctor>> filterByDept(string dept)
        {
            var doctors = await _doctorRepo.GetAll();
            List<Doctor> doctorByDept = doctors.Where(d => d.Specialization == dept).ToList();
            return doctorByDept;
        }



    }
}
