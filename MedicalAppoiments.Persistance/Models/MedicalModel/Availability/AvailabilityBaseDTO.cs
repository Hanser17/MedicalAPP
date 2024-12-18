﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAppoiments.Persistance.Models.MedicalModel.Availability
{
    public abstract class AvailabilityBaseDTO
    {
        public short SAvailabilityModeID { get; set; }
        public string? AvailabilityMode { get; set; }

        public bool IsActive { get; set; }

    }
}
