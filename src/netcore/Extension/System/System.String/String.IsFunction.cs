#region Usings

using System;

#endregion

namespace mdigit.netcore
{
    /// <summary>
    ///     Some extension methods for the <see cref="T:String" /> class.
    /// </summary>
    public static partial class StringEx
    {
        /// <summary>
        ///     Gets a value indicating whether the given option is a function.
        /// </summary>
        /// <param name="option">The option.</param>
        /// <returns>Returns a value indicating whether the given option is a function or not.</returns>
        public static Boolean IsFunction( this String option ) => option != null &&
                                                                  ( option.Equals( Constants.Send, StringComparison.InvariantCultureIgnoreCase ) ||
                                                                    option.Equals( Constants.Start, StringComparison.InvariantCultureIgnoreCase ) ||
                                                                    option.Equals( Constants.Stop, StringComparison.InvariantCultureIgnoreCase ) ||
                                                                    option.Equals( Constants.Test, StringComparison.InvariantCultureIgnoreCase ) );
    }
}