

using MedicalAppoiments.Domain.Entities.insurance;

namespace MedicalAppoiments.Persistance.Models.insuranseModel
{
    public class InsuranceProvidersUpdateDTO : InsuranceProvidersBaseDTO
    {

        public int InsuranceProviderID { get; set; }

        public string InsuranceProviderName { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
