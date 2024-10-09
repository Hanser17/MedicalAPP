

using MedicalAppoiments.Domain.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppoiments.Domain.Entities.insurance
{
    [Table("NetworkType", Schema = "insurance")]
    public class NetworkType : BaseEntity
    {
       
        public string? Description { get; set; }

        public int NetworkTypeId { get; set; }
        public string? Name { get; set; }
      

    }
}
