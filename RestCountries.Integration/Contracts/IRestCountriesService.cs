using System.Collections.Generic;
using System.Threading.Tasks;
using RestCountries.Integration.Models;

namespace RestCountries.Integration.Contracts
{
    /// <summary>
    /// The Rest Countries Service interface.
    /// </summary>
    public interface IRestCountriesService
    {
        /// <summary>
        /// Gets the information for all the countries.
        /// </summary>
        /// <returns>an IEnumerable of Country.</returns>
        Task<IEnumerable<Country>> GetAllAsync();

        /// <summary>
        /// Gets a single country by name.
        /// </summary>
        /// <param name="name">the Name of the country to get.</param>
        /// <returns>a Country object.</returns>
        Task<Country> GetByNameAsync(string name);

        /// <summary>
        /// Gets a single country by code.
        /// </summary>
        /// <param name="code">the Country code.</param>
        /// <returns>a Country object.</returns>
        Task<Country> GetByCodeAsync(string code);
    }
}