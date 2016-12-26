using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapperTests
{
    public class Destination
    {
        public int CompletelyIdenticalProperty { get; set; }
        public double NotExistSetProperty { get; }
        public short CompletelyDifferentTypesProperty { get; set; }
        public double ConvertibleProperty { get; set; }
        public long InconvertibilityProperty { get; set; }
        public int SimpleProperty { get; set; }
        public object SameReferenceTypeProperty { get; set; }
        public IEnumerable<string> ConvertibleReferenceTypeProperty { get; set; }
        public IEnumerable<int> InconvertibleReferenceTypeProperty { get; set; }

        public override bool Equals(object obj)
        {
            var destination = obj as Destination;

            if (ReferenceEquals(null, destination)) return false;
            if (ReferenceEquals(this, destination)) return true;

            return Equals(CompletelyIdenticalProperty, destination.CompletelyIdenticalProperty) &&
                   Equals(NotExistSetProperty, destination.NotExistSetProperty) &&
                   Equals(CompletelyDifferentTypesProperty, destination.CompletelyDifferentTypesProperty) &&
                   Equals(ConvertibleProperty, destination.ConvertibleProperty) &&
                   Equals(InconvertibilityProperty, destination.InconvertibilityProperty) &&
                   Equals(SimpleProperty, destination.SimpleProperty) &&
                   Equals(SameReferenceTypeProperty, destination.SameReferenceTypeProperty) &&
                   Equals(ConvertibleReferenceTypeProperty, destination.ConvertibleReferenceTypeProperty) &&
                   Equals(InconvertibleReferenceTypeProperty, destination.InconvertibleReferenceTypeProperty);
        }
    }
}
