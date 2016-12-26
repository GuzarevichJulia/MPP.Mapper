using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapperLibrary
{
    public interface IMapper
    {
        TDestination Map<TSource, TDestination>(TSource source) where TDestination : new();
    }
}
