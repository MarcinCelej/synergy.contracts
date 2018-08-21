using System;
using System.Reflection;
using JetBrains.Annotations;

namespace Synergy.Contracts.Extensions
{
    internal static class TypeExtensions
    {
        public static bool IsInstanceOfType(this Type type, [CanBeNull] object obj)
        {
            return obj != null && type.GetTypeInfo().IsAssignableFrom(obj.GetType().GetTypeInfo());
        }
    }
}