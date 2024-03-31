using System.Runtime.Serialization;

namespace Auth.Domain.Exceptions;

public class GlobalException : Exception
{
    public GlobalException() { }

    public GlobalException(string message) : base(message) { }

    public GlobalException(string message, Exception innerException) : base(message, innerException) { }

    public GlobalException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}
