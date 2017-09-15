using System;

namespace DCA.Core.Data.Exceptions
{
    public class DataFaultException : Exception
    {
        public DataFaultException(Exception innerException)
            : base(innerException.Message, innerException)
        {
        }
    }
}
