using System;
using System.Collections.Generic;
using System.Linq;

namespace RestCountries.Integration.Models
{
    public class Country
    {
        public string Name { get; set; }

        public string OfficialName { get; set; }

        public string CountryCodeIso2 { get; set; }

        public string CountryCodeIso3 { get; set; }

        public string CountryCodeNum { get; set; }

        public string Flag { get; set; }

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

        public InternationalDialingCode DialingCode { get; set; }

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
