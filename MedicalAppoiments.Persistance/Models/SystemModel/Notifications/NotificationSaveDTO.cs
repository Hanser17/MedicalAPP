using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAppoiments.Persistance.Models.SystemModel.Notifications
{
    public class NotificationSaveDTO : NotificationBaseDTO
    {
        public DateTime? SentAt { get; set; } 
    }
}
