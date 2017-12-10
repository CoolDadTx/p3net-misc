using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace WebApiDemo.Models
{
    /// <summary>Represents a country.</summary>
    [Description("Represents a country.")]
    public class Country
    {
        public Country ()
        {
            Regions = new List<RegionModel>();
        }

        /// <summary>The unique ID of the country.</summary>
        [Description("The unique ID of the country.")]
        public int Id { get; set; }

        /// <summary>The name of the country.</summary>
        [Description("The name of the country.")]
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        /// <summary>The 2 character ISO code.</summary>
        [Description("The 2 character ISO code.")]
        [Required(AllowEmptyStrings = false)]
        [StringLength(2, MinimumLength = 2)]
        public string IsoCode { get; set; }

        /// <summary>The list of regions in the country.</summary>
        [Description("The list of regions in the country.")]
        public List<RegionModel> Regions { get; private set; }
    }
}