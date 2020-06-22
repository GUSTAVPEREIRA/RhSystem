namespace RHSystem.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class AuthenticationException : Exception
    {
        public AuthenticationException()
        {
        }

        public AuthenticationException(string message) : base(message)
        {
        }

        public AuthenticationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AuthenticationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public override string Message => "Unauthenticated user!";
    }
}