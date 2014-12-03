using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TMBF.Models
{
    public class SearchParameterModel
    {
        [Display(Name = "Month")]
        public string Month { get; set; }
        [Display(Name = "Year")]
        public string Year { get; set; }
        [Display(Name = "Output Format ")]
        public string OutputFormat { get; set; }
        [Display(Name = "Service")]
        public string ServiceID { get; set; }
        [Display(Name = "Country code")]
        public string CountryID { get; set; }
    }
}