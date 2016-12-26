using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapperTests
{
    public class Source
    {
        public int CompletelyIdenticalProperty { get; set; }
        public double NotExistSetProperty { get; set; }
        public string CompletelyDifferentTypesProperty { get; set; }
        public long ConvertibleProperty { get; set; }
        public float InconvertibilityProperty { get; set; }
        public object SameReferenceTypeProperty { get; set; }
        public List<string> ConvertibleReferenceTypeProperty { get; set; }
        public IEnumerable<string> InconvertibleReferenceTypeProperty { get; set; }
    }
}
