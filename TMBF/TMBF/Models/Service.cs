using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Collections.Generic;

namespace TMBF.Models
{
    public class Service
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public int SourceCountry { get; set; }

        public int DestinationCountry { get; set; }

        public double PeekRate { get; set; }

        public double OffPeekRate { get; set; }

        public DateTime RateEffectiveDate { get; set; }

        public DateTime RateEndDate { get; set; }
        //
        public virtual ICollection<Customer> Customers {  get;  set; }
    }
}
