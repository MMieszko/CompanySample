namespace Company.Domain.Exceptions
{
    public class ObjectCreationException : DomainException
    {
        public string EntityName { get; }

        public ObjectCreationException(string entityName, string message) 
            : base(message, DomainExceptionCodes.ObjectCreation)
        {
            this.EntityName = entityName;
        }
    }
}