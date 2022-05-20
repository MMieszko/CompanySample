namespace Company.Domain.Exceptions
{
    public class ObjectUpdateException : DomainException
    {
        public string EntityName { get; }
        public string PropertyName { get; }

        public ObjectUpdateException(string entityName, string propertyName)
            : this(entityName, propertyName, string.Empty)
        {
        }

        public ObjectUpdateException(string entityName, string propertyName, string message)
            : base(message, DomainExceptionCodes.ObjectUpdate)
        {
            this.EntityName = entityName;
            this.PropertyName = propertyName;
        }
    }
}