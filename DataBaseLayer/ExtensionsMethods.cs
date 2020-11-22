using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DataBaseLayer
{
    public static class ExtensionsMethods
    {
        public static IEnumerable<PropertyInfo> GetPublicProperties(this Type type)
        {
            if (!type.IsInterface)
                return type.GetProperties();

            return (new Type[] { type })
                   .Concat(type.GetInterfaces())
                   .SelectMany(i => i.GetProperties());
        }
    }
}
