using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TMBF.Models
{
    
    public class User
    {
       public enum Role
        {
            Admin = 0, Customer = 1, SalesRep = 2
        };

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public  long ID { get; set; }
        [Display(Name = "User Name")]
        public string UserName { get; set; }


        [Display(Name = "First Name")]
        public  string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        public Role role { get; set; }
        
    }
}