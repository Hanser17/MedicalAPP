

namespace MedicalAppoiments.Persistance.Models.insuranseModel
{
    public class InsuranceProvidersModel
    {
        public int InsuranceProviderID { get; set; }
        public string InsuranceProviderName { get; set; }

        public string InsuranceProviderType { get; set; }
        public string CoverageDetails { get; set; }
        public decimal? MaxCoverageAmount { get; set; }

        public bool IsPreferred { get; set; }

        public bool IsActive { get; set; }

    }
}
