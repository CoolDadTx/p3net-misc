using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Http;

using WebApiDemo.Models;

namespace WebApiDemo.Controllers.Api
{
    /// <summary>Provides access to country resources.</summary>
    [RoutePrefix("api/countries")]
    [Description("Provides access to country resources.")]
    public class CountryController : ApiController
    {
        /// <summary>Gets all countries.</summary>
        /// <returns>The list of countries.</returns>
        [HttpGet]
        [Route("")]
        [Description("Gets all countries.")]
        [return: Description("The list of countries.")]
        public IEnumerable<Country> GetAll ()
        {
            return CountryRepository.Default.GetAll();
        }

        /// <summary>Gets a specific country.</summary>
        /// <param name="id">The ID of the country.</param>
        /// <returns>The country, if found.</returns>
        [HttpGet]
        [Route("{id:int}")]
        [Description("Gets a specific country.")]
        [return: Description("The country, if found.")]
        public Country Get ( [Description("The ID of the country.")] int id )
        {
            return CountryRepository.Default.Get(id);
        }

        /// <summary>Updates a country.</summary>
        /// <param name="id">The ID of the country.</param>
        /// <param name="country">The updated country information.</param>
        [HttpPost]
        [Route("{id:int}")]
        [Description("Updates a country.")]
        public void Update ( [Description("The ID of the country.")] int id, [Description("The updated country information.")] Country country )
        {
            var existing = CountryRepository.Default.Get(id);

            existing.IsoCode = country.IsoCode;
            existing.Name = country.Name;
        }
    }
}