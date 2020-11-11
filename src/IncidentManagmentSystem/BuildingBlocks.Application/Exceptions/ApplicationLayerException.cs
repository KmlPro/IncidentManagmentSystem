using System;

namespace BuildingBlocks.Application.Exceptions
{
    public class ApplicationLayerException : Exception
    {
        public ApplicationLayerException(string message) : base(message)
        {
        }

        public override string ToString()
        {
            return $"{this.Message}";
        }
    }
}
