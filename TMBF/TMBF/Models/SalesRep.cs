using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Collections.Generic;

namespace TMBF.Models
{
    public class SalesRep : User
    {
        public virtual ICollection<Customer> Customers { get; set; }
    }    
}