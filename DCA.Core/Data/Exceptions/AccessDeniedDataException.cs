using System;

namespace DCA.Core.Data.Exceptions
{
    public class AccessDeniedDataException : Exception
    {
        public AccessDeniedDataException(Exception innerException)
            : base(innerException.Message, innerException)
        {
        }
    }
}
