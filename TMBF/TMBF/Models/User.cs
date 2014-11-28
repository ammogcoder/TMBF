using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TMBF.Models
{
    public abstract class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public  long ID { get; set; }
        public  string Name { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
        //tuan edit
    }
}