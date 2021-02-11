using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaggageTransfer.Models.EntityModels
{
    public class UserEnquiry
    {
        public long Id { get; set; }

        public string UserId { get; set; }

        public float StartLat { get; set; }

        public float StartLong { get; set; }

        public float EndLat { get; set; }

        public float EndLong { get; set; }
          
        public RequestType RequestType { get; set; }

        public DateTime ActiveTill { get; set; }

        public BaggageRequest EnquiryRequest { get; set; }
    }
}