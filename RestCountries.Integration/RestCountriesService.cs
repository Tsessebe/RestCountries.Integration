using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using RestCountries.Integration.Contracts;
using RestCountries.Integration.Models;

namespace RestCountries.Integration
{
    /// <summary>
    /// The Rest Countries Service class.
    /// </summary>
    public class RestCountriesService : IRestCountriesService
    {
        private const string RemoteAddress = "https://restcountries.com/v3.1";

        private readonly HttpClient httpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="RestCountriesService"/> class.
        /// </summary>
        /// <param name="httpClient">the httpClient.</param>
        public RestCountriesService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Country>> GetAllAsync()
        {
            var result = await GetData("/all");

            return result.OrderBy(_ => _.Name);
        }

        /// <inheritdoc />
        public async Task<Country> GetByNameAsync(string name)
        {
            var result = await GetData($"/name/{name}");

            return result.FirstOrDefault();
        }

        /// <inheritdoc />
        public async Task<Country> GetByCodeAsync(string code)
        {
            var result = await GetData($"/alpha/{code}");

            return result.FirstOrDefault();
        }

        private async Task<IEnumerable<Country>> GetData(string endpoint)
        {
            var res = await httpClient.GetAsync(RemoteAddress + endpoint);
            if (res.StatusCode != HttpStatusCode.OK)
            {
                throw new HttpRequestException(res.ReasonPhrase);
            }
            var jsonResult = await res.Content.ReadAsStringAsync();

            var response = JArray.Parse(jsonResult);
            var result = from countries in response
                select new Country
                {
                    Name = (string)countries["name"]["common"],
                    OfficialName = (string)countries["name"]["official"],
                    CountryCodeIso2 = (string)countries["cca2"],
                    CountryCodeIso3 = (string)countries["cca3"],
                    CountryCodeNum = (string)countries["ccn3"],
                    Flag = (string)countries["flag"],
                    DialingCode = new InternationalDialingCode
                    {
                        Root = (string)countries["idd"]["root"],
                        Suffixes = countries["idd"]["suffixes"]?.Values<string>().ToList(),
                    }
                };

            return result;
        }
    }
}
