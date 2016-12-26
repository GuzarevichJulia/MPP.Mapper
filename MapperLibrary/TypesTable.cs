using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapperLibrary
{
    public class TypesTable
    {
        private readonly Dictionary<Type, List<Type>> ConvertableTypes = new Dictionary<Type, List<Type>>() {
            { typeof(sbyte), new List<Type> { typeof(short), typeof(int), typeof(long), typeof(float), typeof(double),
                typeof(decimal) }},
            { typeof(byte), new List<Type> { typeof(short), typeof(ushort), typeof(int), typeof(uint), typeof(long),
                typeof(ulong), typeof(float), typeof(double), typeof(decimal) } },
            { typeof(short), new List<Type> { typeof(int), typeof(long), typeof(float), typeof(double), typeof(decimal) } },
            { typeof(ushort), new List<Type> { typeof(int), typeof(uint), typeof(long), typeof(ulong), typeof(float),
                typeof(double), typeof(decimal) } },
            { typeof(int), new List<Type> { typeof(long), typeof(float), typeof(double), typeof(decimal) } },
            { typeof(uint), new List<Type> { typeof(long), typeof(ulong), typeof(float), typeof(double), typeof(decimal) } },
            { typeof(long), new List<Type> { typeof(float), typeof(double), typeof(decimal) } },
            { typeof(ulong), new List<Type> { typeof(float), typeof(double), typeof(decimal) } },
            { typeof(char), new List<Type> { typeof(ushort), typeof(int), typeof(uint), typeof(long), typeof(ulong),
                typeof(float), typeof(double), typeof(decimal) } },
            { typeof(float), new List<Type> { typeof(double) } }
            };

        public bool Convert(Type sourceType, Type destinationType)
        {
            if( sourceType == null)
            {
                throw new ArgumentNullException(nameof(sourceType));
            }
            if (destinationType == null)
            {
                throw new ArgumentNullException(nameof(destinationType));
            }

            if(sourceType == destinationType)
            {
                return true;
            }
            if(!destinationType.IsAssignableFrom(sourceType))
            {
                return ConvertableTypes.ContainsKey(sourceType) && ConvertableTypes[sourceType].Contains(destinationType);
            }
            return true;
        }
    }
}
