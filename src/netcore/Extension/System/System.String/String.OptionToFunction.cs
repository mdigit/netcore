#region Usings

using System;
using mdigit.netcore.Definition.Enums;

#endregion

namespace mdigit.netcore
{
    /// <summary>
    ///     Some extension methods for the <see cref="T:String" /> class.
    /// </summary>
    public static partial class StringEx
    {
        /// <summary>
        ///     Converts the given function name to a function enumerator.
        /// </summary>
        /// <param name="option"></param>
        /// <returns>Returns a function.</returns>
        public static Function OptionToFunction( this String option )
        {
            if ( option.Equals( Constants.Send, StringComparison.InvariantCultureIgnoreCase ) )
                return Function.SendMessage;

            if ( option.Equals( Constants.Start, StringComparison.InvariantCultureIgnoreCase ) )
                return Function.StartListening;

            if ( option.Equals( Constants.Stop, StringComparison.InvariantCultureIgnoreCase ) )
                return Function.StoptListening;

            if ( option.Equals( Constants.Test, StringComparison.InvariantCultureIgnoreCase ) )
                return Function.Test;

            return Function.Unknow;
        }
    }
}