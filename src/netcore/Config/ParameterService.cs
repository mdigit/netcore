namespace mdigit.netcore
{
    /// <summary>
    ///     The parameter service class.
    /// </summary>
    public class ParameterService : IParameterService
    {
        /// <summary>
        ///     Gets the parameters.
        /// </summary>
        /// <returns>Returns the parameters.</returns>
        public IParameters GetParameters() => new Parameters
        {
            HostName = "localhost",
            QueueName = "hello"
        };
    }
}