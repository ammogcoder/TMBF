using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace TMBF
{
    public class Call
    {
        public int ID { get; set; }

        public DateTime CallDate { get; set; }

        public int CallTime { get; set; }

        public TimeSpan Duration { get; set; }

        public int SourceCountry { get; set; }

        public int DestinationCountry { get; set; }        

        public int ReceiverNo { get; set; }

        public int CustomerID { get; set; }



        public virtual Customer Customer { get; set; }
    }
}
