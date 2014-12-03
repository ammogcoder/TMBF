using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using TMBF.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace TMBF.Models
{
    [Table("Admin")]
    public class Admin:User
    {
    }
}
