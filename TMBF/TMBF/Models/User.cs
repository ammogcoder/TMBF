using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TMBF
{
    public abstract class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public  int ID { get; set; }
        public  string Name { get; set; }
        public  string Password { get; set; }


    }
}