using System;

namespace BuildingBlocks.Application.Abstract
{
    public class ApplicationLayerException : Exception
    {
        public ApplicationLayerException(string message) : base(message)
        {
        }
    }
}
