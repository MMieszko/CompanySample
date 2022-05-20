using Company.Domain.Abstraction;
using Company.Domain.Exceptions;
using Company.Domain.Extensions;

namespace Company.Domain.Models.Shared
{
    public class Gender : SinglePropertyValueObject<GenderEnum>
    {
        public Gender(GenderEnum value)
            : base(value)
        {
            if (!value.IsDefined() || value == GenderEnum.None)
            {
                throw new ObjectCreationException(nameof(Gender), $"Invalid value for {nameof(GenderEnum)}: {value}");
            }
        }
    }
}