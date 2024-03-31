using System.Runtime.Serialization;

namespace Auth.Domain.Exceptions;

public class ItemNotFoundException : Exception
{
    public ItemNotFoundException() { }

    public ItemNotFoundException(string message) : base(message) { }

    public ItemNotFoundException(string message, Exception innerException) : base(message, innerException) { }

    public ItemNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}
