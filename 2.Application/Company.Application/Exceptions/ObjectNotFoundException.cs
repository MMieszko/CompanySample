namespace Company.Application.Exceptions
{
    public class ObjectNotFoundException : ApplicationException
    {
        public string SeekObjectName { get; }

        public ObjectNotFoundException(string seekObjectName, string message)
            : base(ApplicationExceptionCodes.ObjectNotFound, message)
        {
            this.SeekObjectName = seekObjectName;
        }

        public ObjectNotFoundException(string seekObjectName)
            : this(seekObjectName, string.Empty)
        {
        }
    }
}