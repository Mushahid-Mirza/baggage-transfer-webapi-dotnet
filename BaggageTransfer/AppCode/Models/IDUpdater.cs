using System.Collections.Generic;

namespace BaggageTransfer.Models
{
    public class IDUpdater<T>
    {
        public List<T> AddIDs { get; set; }

        public List<T> NewIDs { get; set; }

        public List<T> OldIDs { get; set; }

        public List<T> RemoveIDs { get; set; }
    }
}
