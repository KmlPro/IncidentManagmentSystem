namespace BuildingBlocks.Application.OutputPort
{
    public interface IOutputPortResourceNotFound
    {
        /// <summary>
        ///     Informs the resource was not found.
        /// </summary>
        void ResourceNotFound();
    }
}
