namespace Company.Domain.Exceptions
{
    public abstract class DomainException : CompanyException
    {
        protected DomainException(string message, int code)
            : base(code, message)
        {
        }
    }
}