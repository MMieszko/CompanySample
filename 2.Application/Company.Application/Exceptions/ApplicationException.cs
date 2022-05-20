using Company.Domain.Exceptions;

namespace Company.Application.Exceptions
{
    public abstract class ApplicationException : CompanyException
    {
        protected ApplicationException(int code, string message) 
            : base(code, message)
        {
        }
    }
}