namespace mdigit.netcore
{
    /// <summary>
    ///     The receiver service interface.
    /// </summary>
    public interface IReceiverService
    {
        /// <summary>
        ///     Start waiting for message from the message broker.
        /// </summary>
        void StartListening();

        /// <summary>
        ///     Stops waiting for message from the message broker.
        /// </summary>
        void StopListening();
    }
}