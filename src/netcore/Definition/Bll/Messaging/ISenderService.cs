namespace mdigit.netcore
{
    /// <summary>
    ///     The sender service interface.
    /// </summary>
    public interface ISenderService
    {
        /// <summary>
        ///     Sends a message to the message broker.
        /// </summary>
        void Send();
    }
}