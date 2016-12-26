using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace MapperLibrary
{
    public class Mapper : IMapper
    {
        private Cache сache;
        private TypesTable typesTable;
        private Compiler compiler;
        private Dictionary<string, PropertyInfo> sourceProperties;
        private Dictionary<string, PropertyInfo> destinationProperties;

        public Mapper()
        {
            сache = new Cache();
            typesTable = new TypesTable();
            compiler = new Compiler();
        }

        public TDestination Map<TSource, TDestination>(TSource source) where TDestination : new()
        {
            if(source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            SourceDestinationPair srcDestPair = new SourceDestinationPair(typeof(TSource), typeof(TDestination));
            Func<TSource, TDestination> lambdaExp = null;
                        
            Delegate delegateExp = null;
            if (!сache.TryGetValue(srcDestPair, out delegateExp))
            {
                sourceProperties = GetProperties(typeof(TSource));
                destinationProperties = GetProperties(typeof(TDestination));
                List<PropertyInfo> mappingProperties = GetMappingProperties(sourceProperties, destinationProperties);
                lambdaExp = compiler.Compile<TSource, TDestination>(mappingProperties);
                сache.Add(srcDestPair, lambdaExp);
            }
            else
            {
                lambdaExp = (Func<TSource, TDestination>)delegateExp;
            }

            return lambdaExp(source);
        }        

        private Dictionary<string, PropertyInfo> GetProperties(Type type)
        {
            Dictionary<string, PropertyInfo> properties = new Dictionary<string, PropertyInfo>();
            PropertyInfo[] propertyInfo = type.GetProperties();
            foreach(PropertyInfo property in propertyInfo)
            {
                properties.Add(property.Name, property);
            }
            return properties;
        }

        private List<PropertyInfo> GetMappingProperties(Dictionary<string, PropertyInfo> sourceProperties, Dictionary<string, PropertyInfo> destinationProperties)
        {
            List<PropertyInfo> mapProperties = new List<PropertyInfo>();
            PropertyInfo destPropertyInfo = null;
            foreach(string srcPropertyName in sourceProperties.Keys)
            {
                if (CheckProperty(srcPropertyName, out destPropertyInfo))
                {
                    mapProperties.Add(destPropertyInfo);
                }
            }
            return mapProperties;
        }

        private bool CheckProperty(string srcPropertyName, out PropertyInfo destPropertyInfo)
        {
            if (destinationProperties.TryGetValue(srcPropertyName, out destPropertyInfo))
            {
                return destPropertyInfo.CanWrite && typesTable.Convert(sourceProperties[srcPropertyName].PropertyType, destPropertyInfo.PropertyType);                
            }
            return false; 
        }
    }
}
