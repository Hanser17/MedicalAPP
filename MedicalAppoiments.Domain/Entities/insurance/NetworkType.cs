

using MedicalAppoiments.Domain.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppoiments.Domain.Entities.insurance
{
    [Table("NetworkType", Schema = "insurance")]
    public class NetworkType : BaseEntity_insurance
    {
       
        public string? Description { get; set; }
       

    }
}
