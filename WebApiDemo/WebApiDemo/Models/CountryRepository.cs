using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiDemo.Models
{
    public class CountryRepository
    {
        static CountryRepository()
        {
            Default = new CountryRepository();

            var unitedStates = new Country() { Id = 1, Name = "United States", IsoCode = "US" };
            unitedStates.Regions.Add(new RegionModel() { Id = 1, Name = "Alabama" });
            unitedStates.Regions.Add(new RegionModel() { Id = 2, Name = "Ohio" });
            unitedStates.Regions.Add(new RegionModel() { Id = 3, Name = "Texas" });
            Default.m_countries.Add(unitedStates);

            var canada = new Country() { Id = 2, Name = "Canada", IsoCode = "CA" };
            canada.Regions.Add(new RegionModel() { Id = 4, Name = "Alberta" });
            canada.Regions.Add(new RegionModel() { Id = 4, Name = "Ontario" });
            Default.m_countries.Add(canada);
        }

        public static readonly CountryRepository Default;

        public Country Get ( int id )
        {
            return m_countries.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Country> GetAll ()
        {
            return m_countries;
        }
        
        private readonly List<Country> m_countries = new List<Country>();
    }
}