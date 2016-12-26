using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using MapperLibrary;

namespace MapperTests
{
    [TestFixture]
    public class MapperTests
    {
        private Mapper mapper;

        [SetUp]
        public void SetUp()
        {
            mapper = new Mapper();
        }

        [Test]
        public void Map_WhenPropertyCompletelyIdentical_ShouldAssignTheSameValue()
        {
            int value = 120797;
            Source source = new Source()
            {
                CompletelyIdenticalProperty = value
            };
            Destination destination = mapper.Map<Source, Destination>(source);

            // act
            var actual = destination.CompletelyIdenticalProperty;

            // assert
            var expected = value;
            Assert.AreEqual(expected, actual);       
        }

        [Test]
        public void Map_WhenPropertyWithoutSetter_ShouldBeZero()
        {
            double value = 1207.97;
            Source source = new Source()
            {
                NotExistSetProperty = value
            };
            Destination destination = mapper.Map<Source, Destination>(source);

            // act
            var actual = destination.CompletelyIdenticalProperty;

            // assert
            var expected = 0;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Map_WhenPropertyConvertible_ShouldAssignTheSameValue()
        {
            // arrange
            long value = 120797;
            Source source = new Source()
            {
                ConvertibleProperty = value
            };
            Destination destination = mapper.Map<Source, Destination>(source);

            // act
            var actual = destination.ConvertibleProperty;

            // assert
            var expected = value;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Map_WhenPropertyInconvertibility_ShouldBeZero()
        {
            float value = 12079.7F;
            Source source = new Source()
            {
                InconvertibilityProperty = value
            };
            Destination destination = mapper.Map<Source, Destination>(source);

            // act
            var actual = destination.InconvertibilityProperty;

            // assert
            var expected = 0;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Map_WhenPropertyWithTheSameReferenceTypes_ShouldAssignTheSameValue()
        {
            object value = new object();
            Source source = new Source()
            {
                SameReferenceTypeProperty = value
            };
            Destination destination = mapper.Map<Source, Destination>(source);

            // act
            var actual = destination.SameReferenceTypeProperty;

            // assert
            var expected = value;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Map_WhenReferencePropertyConvertible_ShouldAssignTheSameValue()
        {
            List<string> value = new List<string>();
            Source source = new Source()
            {
                ConvertibleReferenceTypeProperty = value
            };
            Destination destination = mapper.Map<Source, Destination>(source);

            // act
            var actual = destination.ConvertibleReferenceTypeProperty;

            // assert
            var expected = value;
            Assert.AreSame(expected, actual);
        }

        [Test]
        public void Map_WhenReferencePropertyInconvertible_ShouldBeNull()
        {
            IEnumerable<string> value = new List<string>();
            Source source = new Source()
            {
                InconvertibleReferenceTypeProperty = value
            };
            Destination destination = mapper.Map<Source, Destination>(source);

            // act
            var actual = destination.InconvertibleReferenceTypeProperty;

            // assert
            IEnumerable<int> expected = null;
            Assert.AreSame(expected, actual);
        }

        [Test]
        public void Map_WhenPropertyWithCompletelyDifferentTypes_ShouldBeZero()
        {
            string value = "test";
            Source source = new Source()
            {
                CompletelyDifferentTypesProperty = value
            };
            Destination destination = mapper.Map<Source, Destination>(source);

            // act
            var actual = destination.CompletelyDifferentTypesProperty;

            // assert
            var expected = 0;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Map_WhenSourceIsEmptyClass_ShouldBeEmptyDestination()
        {
            EmptyClass source = new EmptyClass();

            // act
            var actual = mapper.Map<EmptyClass, Destination>(source);

            // assert
            var expected = new Destination();
            Assert.AreEqual(expected, actual);
        }

        [Test] 
        public void Map_WhenDestinationIsEmptyClass_ShouldBeEmpty()
        {
            string value = "string";
            Source source = new Source()
            {
                CompletelyDifferentTypesProperty = value
            };

            // act
            EmptyClass actual = mapper.Map<Source, EmptyClass>(source);

            // assert
            var expected = new EmptyClass();
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void Map_WhenSourceIsNull_ShouldThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => mapper.Map<Source, Destination>(null));
        }
        
    }
}
