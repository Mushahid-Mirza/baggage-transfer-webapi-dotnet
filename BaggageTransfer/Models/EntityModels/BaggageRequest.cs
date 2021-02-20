using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BaggageTransfer.Models.EntityModels
{
    public class BaggageRequest
    {
        public long Id { get; set; }

        [ForeignKey("RequesterEnquiry")]
        public long RequesterEnquiryId { get; set; }
        public UserEnquiry RequesterEnquiry { get; set; }

        [ForeignKey("MoverEnquiry")]
        public long MoverEnquiryrId { get; set; }
        public UserEnquiry MoverEnquiry { get; set; }
          
        public string ApproximateWeight { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public decimal ApprovedCost { get; set; } 

        public BookingStatus BookingStatus { get; set; }
    }
}