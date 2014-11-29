using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TMBF.Models
{
    [Table("Customer")]
    public class Customer: User
    {
        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }        
        public string City { get; set; }
        public string State { get; set; }
        [Display(Name = "Zip Code")]
        public int ZipCode { get; set; }
        [Display(Name = "% Commision to Representative")]
        public double CommisionForSalesRep { get; set; }
        [Display(Name = "Phone Number")]
        public string PhoneNo { get; set; }

        public int CountryID { get; set; }
        public int ServiceID { get; set; }
        public long SalesRepID { get; set; }

        public virtual Country Country { get; set; }
        public virtual Service Service { get; set; }
        public virtual SalesRep SalesRep { get; set; }
        public virtual ICollection<Call> Calls { get; set; }

    }
}
