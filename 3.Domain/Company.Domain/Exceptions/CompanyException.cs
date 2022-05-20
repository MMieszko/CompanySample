using System;

namespace Company.Domain.Exceptions
{
    public abstract class CompanyException : Exception
    {
        public int Code { get; }

        protected CompanyException(int code, string message)
            : base(message)
        {
            this.Code = code;
        }
    }
}