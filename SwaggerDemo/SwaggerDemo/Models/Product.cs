using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SwaggerDemo.Models
{
    /// <summary>Represents a product.</summary>
    [Description("Represents a product.")]
    public class Product
    {
        /// <summary>The unique identifier.</summary>
        [Description("The product identifier")]
        public int Id { get; set; }

        /// <summary>The product name.</summary>
        [Description("The product name")]
        public string Name { get; set; }

        /// <summary>The price.</summary>
        [Description("The base price")]
        public decimal Price { get; set; }
    }
}