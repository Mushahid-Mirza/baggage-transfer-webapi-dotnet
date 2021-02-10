using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaggageTransfer.Models.EntityModels
{
    public class RequestsPayment
    {
        public long Id { get; set; }

        public long BaggageRequestId { get; set; }

        public long EstimatedAmount { get; set; }

        public string PaymentType { get; set; }

        public string PaymentStatus { get; set; }
    }
}