using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TMBF.Models
{
    [Table("SalesRep")]
    public class SalesRep : User
    {        
        public virtual ICollection<Customer> Customers { get; set; }
    }    
}