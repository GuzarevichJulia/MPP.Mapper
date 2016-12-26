using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapperLibrary
{
    public class Cache
    {
        private readonly Dictionary<SourceDestinationPair, Delegate> items;
        
        public Cache()
        {
            items = new Dictionary<SourceDestinationPair, Delegate>();
        }
        public void Add(SourceDestinationPair key, Delegate value)
        {
            items.Add(key, value);
        }

        public bool TryGetValue(SourceDestinationPair key, out Delegate value)
        {
            return items.TryGetValue(key, out value);
        }        
    }
}
