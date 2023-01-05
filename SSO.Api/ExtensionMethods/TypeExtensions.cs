using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SSO.Api.ExtensionMethods
{
    public static class TypeExtensions
    {
        public static T CastTo<T>(this object obj)
        {
            return (T)obj;
        }
    }
}
