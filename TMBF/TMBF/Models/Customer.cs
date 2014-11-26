using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Collections.Generic;

namespace TMBF.Models
{
    public class Customer: User
    {
        public int Country{ get;  set; }

        public string StreetAddress { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public int ZipCode { get; set; }

        public float Commision2Representative { get; set; }

        public int ServiceID { get; set; }

        public int SalesRepID { get; set; }

        public virtual Service Service { get; set; }

        public virtual SalesRep SalesRep { get; set; }

        public virtual ICollection<Call> Calls { get; set; }

    }
}
