namespace Company.Domain.Extensions
{
    public static class IntegerExtensions
    {
        public static bool IsInRange(this int @this, int min, int max)
        {
            return @this >= min && @this <= max;
        }
    }
}