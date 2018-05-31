#region Usings

using System;
using System.Diagnostics;

#endregion

namespace mdigit.netcore
{
    /// <summary>
    ///     The option class.
    /// </summary>
    public class Option
    {
        #region Properties

        /// <summary>
        ///     Gets or sets the key.
        /// </summary>
        public String Key
        {
            [DebuggerStepThrough]
            get;
            [DebuggerStepThrough]
            set;
        }

        /// <summary>
        ///     Gets or sets the function name.
        /// </summary>
        public String FunctionName
        {
            [DebuggerStepThrough]
            get;
            [DebuggerStepThrough]
            set;
        }

        #endregion
    }
}