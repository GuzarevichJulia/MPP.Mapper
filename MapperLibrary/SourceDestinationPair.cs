using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapperLibrary
{
    public class SourceDestinationPair
    {
        public Type Source { get; private set; }
        public Type Destination { get; private set; }

        public SourceDestinationPair(Type source, Type destination)
        {
            Source = source;
            Destination = destination;
        }

        public override bool Equals(Object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!(obj is SourceDestinationPair))
            {
                return false;
            }
            SourceDestinationPair anotherObj = obj as SourceDestinationPair;
            
            return Source.Equals(anotherObj.Source) && Destination.Equals(anotherObj.Destination);
        }
        public override int GetHashCode()
        {
            return Source.GetHashCode() + Destination.GetHashCode();
        }

    }
}
