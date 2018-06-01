#region Usings

using System;
using System.Diagnostics;

#endregion

namespace mdigit.netcore
{
    /// <summary>
    ///     The parameters interface.
    /// </summary>
    public interface IParameters
    {
        #region Properties

        /// <summary>
        ///     Gets or sets the host name.
        /// </summary>
        String HostName
        {
            [DebuggerStepThrough]
            get;
            [DebuggerStepThrough]
            set;
        }

        /// <summary>
        ///     Gets or sets the queue name.
        /// </summary>
        String QueueName
        {
            [DebuggerStepThrough]
            get;
            [DebuggerStepThrough]
            set;
        }

        #endregion
    }
}