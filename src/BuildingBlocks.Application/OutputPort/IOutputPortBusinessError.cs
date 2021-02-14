namespace BuildingBlocks.Application.OutputPort
{
    public interface IOutputPortBusinessError
    {
        /// <summary>
        ///     Informs an businnes rule broken happened.
        /// </summary>
        /// <param name="message">Text description.</param>
        void WriteBusinessRuleError(string message);
    }
}
