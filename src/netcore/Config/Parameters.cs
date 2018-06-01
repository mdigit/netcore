#region Usings

using System;
using System.Diagnostics;

#endregion

namespace mdigit.netcore
{
    /// <summary>
    ///     The parameters class.
    /// </summary>
    public class Parameters : IParameters
    {
        #region Properties

        /// <summary>
        ///     Gets or sets the host name.
        /// </summary>
        public String HostName
        {
            [DebuggerStepThrough]
            get;
            [DebuggerStepThrough]
            set;
        }

        /// <summary>
        ///     Gets or sets the queue name.
        /// </summary>
        public String QueueName
        {
            [DebuggerStepThrough]
            get;
            [DebuggerStepThrough]
            set;
        }

        #endregion
    }
}