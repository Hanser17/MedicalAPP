﻿using MedicalAppoiments.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAppoiments.Domain.Entities.insurance
{
    [Table("InsuranceProviders", Schema = "insurance")]
    public class InsuranceProviders: BaseEntity_insurance
    {
        [Key]
        public int InsuranceProviderID { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public string? Website { get; set; }

        public string Address { get; set; }

        public string? City { get; set; }

        public string? State { get; set; }

        public string? Country { get; set; }

        public string? ZipCode { get; set; }

        public string CoverageDetails { get; set; }

        public string? LogoUrl { get; set; }

        public bool IsPreferred { get; set; }

        public  string? CustomerSupportContact { get; set; }
        public string? AcceptedRegions { get;}

        public double? MaxCoverageAmount { get; set; }

    


    }
}
