#region Usings

using System;
using System.Collections.Generic;

#endregion

namespace mdigit.netcore
{
    /// <summary>
    ///     The options interface.
    /// </summary>
    public interface IOptionsService
    {
        /// <summary>
        ///     Gets the function name for the given option.
        /// </summary>
        /// <param name="option">The option.</param>
        /// <returns>Returns a function name.</returns>
        String GetFunctionName( String option );

        /// <summary>
        ///     Gets the valid options.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Option> GetValidOptions();

        /// <summary>
        ///     Gets a value indicating whether the given option is valid.
        /// </summary>
        /// <param name="option">The option.</param>
        /// <returns>Returns a value indicating whether the given option is valid or not.</returns>
        Boolean ValidateOption( String option );
    }
}