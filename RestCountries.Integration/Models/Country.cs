using System;
using System.Collections.Generic;
using System.Linq;

namespace RestCountries.Integration.Models
{
    /// <summary>
    /// The Country model class
    /// </summary>
    public class Country
    {
        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Official Name.
        /// </summary>
        public string OfficialName { get; set; }

        /// <summary>
        /// Gets or sets the 2 Character ISO Code.
        /// </summary>
        public string CountryCodeIso2 { get; set; }

        /// <summary>
        /// Gets or sets the 3 Character ISO Code.
        /// </summary>
        public string CountryCodeIso3 { get; set; }

        /// <summary>
        /// Gets or sets the Numeric ISO Code.
        /// </summary>
        public string CountryCodeNum { get; set; }

        /// <summary>
        /// Gets or sets the Country Flag uni-character.
        /// </summary>
        public string Flag { get; set; }

        /// <summary>
        /// Gets a list of possible dialing codes.
        /// </summary>
        public List<string> DialingCodes
        {
            get
            {
                if (DialingCode?.Root == null)
                {
                    return new List<string>();
                }

                var result = DialingCode.Suffixes.Select(_ => DialingCode.Root.Equals("+1", StringComparison.InvariantCultureIgnoreCase) ? $"{DialingCode.Root} {_}" : $"{DialingCode.Root}{_}").ToList();
                
                return result;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="InternationalDialingCode"/>.
        /// </summary>
        public InternationalDialingCode DialingCode { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            if (string.IsNullOrEmpty(Flag))
            {
                return this.Name;
            }
            return $"{this.Flag} {this.Name}";
        }
    }
}
