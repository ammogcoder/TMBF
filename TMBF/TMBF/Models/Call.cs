using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TMBF.Models
{
    public class Call
    {
        public long ID { get; set; }

        [Display(Name = "Call Date")]
        [DataType(DataType.Date)]
        public DateTime CallDate { get; set; }

        [Display(Name = "Call Time")]
        public int CallTime { get; set; }

        public int Duration { get; set; }

        [Display(Name = "Source Country")]
        public virtual Country SourceCountry { get; set; }

        [Display(Name = "Destination Country")]
        public virtual Country DestinationCountry { get; set; }

        [Display(Name = "Receiver #")]
        public string ReceiverNo { get; set; }

        [Display(Name = "Caller #")]
        public long CustomerID { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
