

using System.Reflection.Metadata.Ecma335;

namespace MedicalAppoiments.Persistance.Models.usersModel
{
   public  class DoctorUpdateDTO : DoctorBaseDTO
    {
        public int DoctorID { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
