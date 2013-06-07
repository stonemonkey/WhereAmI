using System;
using System.Linq;

namespace WhereAmI.Core.Extensions
{
    public static class TypeExtensions
    {
        private const string TypeSeparator = ",";
        private const char UnusedSymbol = '`';
        private const string TypeFormat = "{0}_{1}_";

        /// <summary>
        /// Generate a more friendly name of a type. 
        /// When the type is generic the output is similar to: BaseType_GenericType_ 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string ToGenericTypeString(this Type type)
        {            
            if (!type.IsConstructedGenericType)
            {
                return type.Name;
            }
            return string.Format(TypeFormat, GetGenericTypeName(type), GetGenericArgumentsName(type));
        }

        private static string GetGenericArgumentsName(Type type)
        {
            return string.Join(TypeSeparator, type.GenericTypeArguments.Select(ToGenericTypeString).ToArray());
        }

        private static string GetGenericTypeName(Type type)
        {
            string typeName = type.GetGenericTypeDefinition().Name;
            return typeName.Substring(0, typeName.IndexOf(UnusedSymbol));
        }
    }

}
