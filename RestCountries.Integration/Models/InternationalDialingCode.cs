using System.Collections.Generic;

namespace RestCountries.Integration.Models
{
    /// <summary>
    /// The International Dialing Code model class.
    /// </summary>
    public class InternationalDialingCode
    {
        /// <summary>
        /// Gets or sets the Root Dialing code.
        /// </summary>
        public string Root { get; set; }

        /// <summary>
        /// Gets or sets a list of possible suffixes.
        /// </summary>
        public List<string> Suffixes { get; set; }
    }
}