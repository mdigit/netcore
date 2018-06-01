#region Usings

using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace mdigit.netcore
{
    /// <summary>
    ///     The options class.
    /// </summary>
    public class OptionsService : IOptionsService
    {
        #region Properties

        /// <summary>
        ///     Gets the option function dictionary.
        /// </summary>
        private Dictionary<String, String> OptionFunctionDictionary => new Dictionary<String, String>
        {
            { Constants.Send, "Send message to message broker" },
            { Constants.Start, "Start listening for messages from message broker" },
            { Constants.Stop, "Stop listening for messages from message broker" },
            { Constants.Test, "Test" }
        };

        #endregion

        /// <summary>
        ///     Gets the function name for the given option.
        /// </summary>
        /// <param name="option">The option.</param>
        /// <returns>Returns a function name.</returns>
        public String GetFunctionName( String option ) => OptionFunctionDictionary.ContainsKey( option ) ? OptionFunctionDictionary[option] : String.Empty;

        /// <summary>
        ///     Gets the valid options.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Option> GetValidOptions() => OptionFunctionDictionary.Select( x => new Option { Key = x.Key, FunctionName = x.Value } )
                                                                                .ToList();

        /// <summary>
        ///     Gets a value indicating whether the given option is valid.
        /// </summary>
        /// <param name="option">The option.</param>
        /// <returns>Returns a value indicating whether the given option is valid or not.</returns>
        public Boolean ValidateOption( String option ) => option.IsFunction();
    }
}