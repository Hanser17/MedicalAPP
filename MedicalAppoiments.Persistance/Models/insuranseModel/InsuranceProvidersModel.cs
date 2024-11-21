

using System.Diagnostics;

namespace MedicalAppoiments.Persistance.Models.insuranseModel
{
    public class InsuranceProvidersModel : InsuranceProvidersBaseDTO
    {
        public int InsuranceProviderID { get; set; }

        public string InsuranceProviderName { get; set; }

        public string InsuranceProviderType { get; set; }
        public bool IsActive { get; set; }

    }
}
