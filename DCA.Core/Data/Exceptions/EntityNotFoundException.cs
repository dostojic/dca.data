using System;

namespace DCA.Core.Data.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(Exception innerException)
            : base(innerException.Message, innerException)
        {
        }
    }
}