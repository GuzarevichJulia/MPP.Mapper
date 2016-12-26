using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace MapperLibrary
{
    public class Compiler
    {
        public Func<TSource, TDestination> Compile<TSource, TDestination>(List<PropertyInfo> mappingProperties)
        {
            if (mappingProperties == null)
            {
                throw new ArgumentNullException(nameof(mappingProperties));
            }

            ParameterExpression node = Expression.Parameter(typeof(TSource), nameof(node));
            List<MemberAssignment> assignmentOperations = GetGeneratedProperties(node, mappingProperties);
            MemberInitExpression newObject = Expression.MemberInit(Expression.New(typeof(TDestination)), assignmentOperations);
            var expressionTree = Expression.Lambda<Func<TSource, TDestination>>(newObject, node);

            return expressionTree.Compile();
        }

        private List<MemberAssignment> GetGeneratedProperties(ParameterExpression node, List<PropertyInfo> mappingProperties)
        {
            List<MemberAssignment> assignmentOperations = new List<MemberAssignment>();
            foreach(PropertyInfo property in mappingProperties)
            {
                MemberExpression memberExp = Expression.Property(node, property.Name);
                UnaryExpression unaryExp = Expression.Convert(memberExp, property.PropertyType);
                MemberAssignment propertyInit = Expression.Bind(property, unaryExp);
                assignmentOperations.Add(propertyInit);
            }

            return assignmentOperations;
        }
    }
}
