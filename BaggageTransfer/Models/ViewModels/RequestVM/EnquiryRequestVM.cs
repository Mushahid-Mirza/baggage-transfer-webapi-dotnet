using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaggageTransfer.Models.ViewModels.RequestVM
{
    public class EnquiryRequestVM
    {
        public string UserId { get; set; }

        public float[] StartGeo { get; set; }

        public float[] EndGeo { get; set; }

        public string RequestType { get; set; }

        public int ActiveTillHours { get; set; }

        public int ActiveTillMinutes { get; set; }
    }
}