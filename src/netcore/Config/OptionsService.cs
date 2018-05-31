#region Usings

using System.Collections.Generic;

#endregion

namespace mdigit.netcore
{
    /// <summary>
    ///     The options class.
    /// </summary>
    public class OptionsService : IOptionsService
    {
        /// <summary>
        ///     Gets the valid options.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Option> GetValidOptions() => new List<Option>
        {
            new Option { Key = "t", FunctionName = "Test" }
        };
    }
}