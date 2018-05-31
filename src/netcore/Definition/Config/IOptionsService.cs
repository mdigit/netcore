#region Usings

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
        ///     Gets the valid options.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Option> GetValidOptions();
    }
}