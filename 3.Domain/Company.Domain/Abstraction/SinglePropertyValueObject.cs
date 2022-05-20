using System.Collections.Generic;

namespace Company.Domain.Abstraction
{
    public abstract class SinglePropertyValueObject<T> : ValueObject
    {
        public T Value { get; }

        protected SinglePropertyValueObject(T value)
        {
            this.Value = value;
        }

        public static implicit operator T(SinglePropertyValueObject<T> author) => author.Value;

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return this.Value;
        }
    }
}