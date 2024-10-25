

namespace MedicalAppoiments.Persistance.Models.usersModel
{
    public class PatientsModel
    {
        
        public string RoleName { get; set; }
        public int PatientID { get; set; }
      
        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public  DateOnly DateOfBirth { get; set; }
        public bool IsActive { get; set; }

        public string InsuranceName { get; set; }
    }
}
