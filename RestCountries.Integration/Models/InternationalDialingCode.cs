using System.Collections.Generic;

namespace RestCountries.Integration.Models
{
    public class InternationalDialingCode
    {
        public string Root { get; set; }

        public List<string> Suffixes { get; set; }
    }
}