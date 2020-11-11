using System;

namespace BuildingBlocks.Application.Exceptions
{
    public class ResourceNotFoundException: Exception
    {
        public ResourceNotFoundException(Exception ex) : base(null, ex)
        {
        }
    }
}
