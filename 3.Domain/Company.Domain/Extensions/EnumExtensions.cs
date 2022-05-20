using System;

namespace Company.Domain.Extensions
{
    public static class EnumExtensions
    {
        public static bool IsDefined<T>(this T @this)
            where T : Enum
        {
            if (@this == null)
                return false;

            return Enum.IsDefined(typeof(T), @this);
        }
    }
}