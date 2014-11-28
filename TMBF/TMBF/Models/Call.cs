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
        public int ID { get; set; }

        [Display(Name = "Call Date")]
        [DataType(DataType.Date)]
        public DateTime CallDate { get; set; }

        [Display(Name = "Call Time")]
        public int CallTime { get; set; }

        public TimeSpan Duration { get; set; }

        [Display(Name = "Source Country")]
        public virtual Country SourceCountry { get; set; }

        [Display(Name = "Destination Country")]
        public virtual Country DestinationCountry { get; set; }

        [Display(Name = "Receiver #")]
        public long ReceiverNo { get; set; }

        [Display(Name = "Caller #")]
        public long CustomerID { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
