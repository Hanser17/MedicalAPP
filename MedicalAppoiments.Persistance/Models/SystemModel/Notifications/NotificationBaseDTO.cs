using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAppoiments.Persistance.Models.SystemModel.Notifications
{
    public abstract class NotificationBaseDTO
    {
        public int NotificationID { get; set; }
        public int UserID { get; set; }

        public string? Message { get; set; }
        public DateTime? SentAt { get; set; }
    }
}
