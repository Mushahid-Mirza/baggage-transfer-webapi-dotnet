using BaggageTransfer.Factories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BaggageTransfer.Models.EntityModels
{
    public class Notification
    {
        public ApplicationUser User { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        public long NotificationId { get; set; }

        public NotificationType NotificationType { get; set; }

        public string Message { get; set; }
    }
}