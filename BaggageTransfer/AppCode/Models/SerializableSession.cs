using System;

namespace BaggageTransfer.Models
{
    [Serializable]
    public class SerializableSession
    {
        public object SessionObject
        {
            get;
            set;
        }
    }
}
