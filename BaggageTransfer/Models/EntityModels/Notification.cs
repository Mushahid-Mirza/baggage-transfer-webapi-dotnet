using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaggageTransfer.Models.EntityModels
{
    public class Notification
    {
        public string UserId { get; set; }

        public long NotificationId { get; set; }

        public NotificationType NotificationType { get; set; }

        public string Message { get; set; }
    }
}