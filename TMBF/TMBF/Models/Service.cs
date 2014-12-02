using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TMBF.Models
{
    public class Service
    {
        public int ID { get; set; }

        public string Name { get; set; }

        [Display(Name = "Source Country")]
        public Country SourceCountry { get; set; }

        [Display(Name = "Destination Country")]
        public Country DestinationCountry { get; set; }

        [Display(Name = "Peek Hr. Rate")]
        public double PeekRate { get; set; }

        [Display(Name = "Off-Peek Hr. Rate")]
        public double OffPeekRate { get; set; }

        [Display(Name = "Rate Effective Date")]
        public DateTime RateEffectiveDate { get; set; }

        [Display(Name = "Rate Expiry Date")]
        public DateTime RateEndDate { get; set; }

        [Display(Name = "Peek Rate Start Time")]
        public int? PeekRateStartTime { get; set; }

        [Display(Name = "Off-Peek Rate Start Time")]
        public int? OffPeekRateStartTime { get; set; }

        public virtual ICollection<Customer> Customers {  get;  set; }
    }
}
