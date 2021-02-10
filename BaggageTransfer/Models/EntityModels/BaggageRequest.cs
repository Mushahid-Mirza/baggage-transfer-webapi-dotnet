using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaggageTransfer.Models.EntityModels
{
    public class BaggageRequest
    {
        public long Id { get; set; }

        public string RequesterId { get; set; }

        public string MoverUserId { get; set; }

        public string StartLocationName { get; set; }

        public string StartGeoPosition { get; set; }

        public string EndLocationName {get;set;}

        public string EndGeoPosition { get; set; }

        public string ApproximateWeight { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public decimal EstimatedCost { get; set; }
    }
}