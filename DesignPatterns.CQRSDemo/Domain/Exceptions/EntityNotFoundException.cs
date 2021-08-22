using System;

namespace DesignPatterns.CQRSDemo.Domain.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public string Entity { get; set; }
        public object Key { get; set; }

        public EntityNotFoundException() { }

        public EntityNotFoundException(string message) : base(message)
        {
        }

        public EntityNotFoundException(string message, Exception innerException) 
            : base(message, innerException) 
        {
        }

        public EntityNotFoundException(string entity, object key)
        {
            Entity = entity;
            Key = key;
        }
    }
}
