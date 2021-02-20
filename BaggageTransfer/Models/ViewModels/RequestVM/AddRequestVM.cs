using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaggageTransfer.Models.ViewModels.RequestVM
{
    public class AddRequestVM
    {
        public long EnquiryId { get; set; }
        public decimal Amount { get; set; }
        public RequestType Type { get; set; }
    }
}