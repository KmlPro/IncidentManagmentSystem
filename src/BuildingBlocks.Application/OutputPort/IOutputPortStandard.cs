namespace BuildingBlocks.Application.OutputPort
{
    /// <typeparam name="TUseCaseOutput">Any IUseCaseOutput.</typeparam>
    public interface IOutputPortStandard<in TUseCaseOutput>
    {
        /// <summary>
        ///     Writes to the Standard Output.
        /// </summary>
        /// <param name="output">The Output Port Message.</param>
        void Standard(TUseCaseOutput output);
    }
}
