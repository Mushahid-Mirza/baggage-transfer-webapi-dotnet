using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaggageTransfer.Models.EntityModels
{
    public class FindUserRquestVM
    {
        public string UserId { get; set; }

        public float[] Start {get;set;}
         
        public float[] Destination { get; set; }

        public  string ReqquestType { get;set;}
        
    }
}