namespace mdigit.netcore
{
    /// <summary>
    ///     The parameter service interface.
    /// </summary>
    public interface IParameterService
    {
        /// <summary>
        ///     Gets the parameters.
        /// </summary>
        /// <returns>Returns the parameters.</returns>
        IParameters GetParameters();
    }
}