

using MedicalAppoiments.Persistance.Models.BaseModel;

namespace MedicalAppoiments.Persistance.Models.usersModel
{
    public class PatientsModel : Basemodel
    {
        
        public string RoleName { get; set; }
        public int PatientID { get; set; }
      
        public  DateOnly DateOfBirth { get; set; }
        public bool IsActive { get; set; }

        public string InsuranceName { get; set; }
    }
}
