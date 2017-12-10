using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApiDemo.Areas.HelpPage.ModelDescriptions;

namespace WebApiDemo.Models
{
    [Description("Represents a region of a country.")]
    [ModelName("Region")]
    public class RegionModel
    {
        [Description("The unique ID of the region.")]
        public int Id { get; set; }

        [Description("The name of the region.")]
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
    }
}