

using MedicalAppoiments.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppoiments.Domain.Entities.system
{
    [Table ("Notifications", Schema ="System")]
    public class Notifications 
    {
        [Key]
        public int NotificationID { get; set; }
        public int UserID { get; set; }

        public string Message { get; set; }
        public DateTime? SentAt { get; set; }

    }
}
