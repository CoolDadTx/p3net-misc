using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SwaggerDemo.Help;
using SwaggerDemo.Models;

namespace SwaggerDemo.Controllers
{
    /// <summary>Provides access to the products.</summary>
    [Description("Provides access to products.")]
    public class ProductController : ApiController
    {
        static ProductController()
        {
            s_products.AddRange(new[]
            {
                new Product() { Id = 1, Name = "Product A", Price = 100.0M },
                new Product() { Id = 2, Name = "Product B", Price = 50.0M },
                new Product() { Id = 3, Name = "Product C", Price = 25.0M },
            });

            s_id = 3;
        }

        /// <summary>Gets the list of products.</summary>
        /// <returns>The products.</returns>
        [Description("Returns the list of products.")]
        [RestResponse("The products.")]
        public IEnumerable<Product> Get ()
        {
            return s_products;
        }

        /// <summary>Gets a product.</summary>
        /// <param name="id">The product identifier.</param>
        /// <returns>The product.</returns>
        [Description("Returns a specific product.")]
        [RestParameter("id", "The product identifier.")]
        [RestResponse("The product, if any.")]
        public Product Get ( int id )
        {
            return s_products.FirstOrDefault(p => p.Id == id);
        }

        /// <summary>Adds a product.</summary>
        /// <param name="value">The new product.</param>
        /// <returns>The new product.</returns>
        [Description("Adds a new product.")]
        [RestParameter("value", "The new product.")]
        [RestResponse("The product.")]
        public Product Post ( [FromBody]Product value )
        {
            var newProduct = new Product()
            {
                Id = ++s_id,
                Name = value.Name,
                Price = value.Price
            };

            s_products.Add(newProduct);

            return newProduct;
        }

        /// <summary>Updates an existing product.</summary>
        /// <param name="id">The identifier.</param>
        /// <param name="value">The product.</param>
        [Description("Adds or updates a product.")]
        [RestParameter("id", "The product identifier.")]
        [RestParameter("value", "The updated product.")]
        public void Put ( int id, [FromBody]Product value )
        {
            var product = Get(id);
            if (product != null)
            {
                product.Name = value.Name;
                product.Price = value.Price;
            } else
            {
                Post(value);
            };
        }

        /// <summary>Deletes a product.</summary>
        /// <param name="id">The identifier.</param>
        [Description("Removes a product.")]
        [RestParameter("id", "The product identifier.")]
        public void Delete ( int id )
        {
            s_products.RemoveAll(p => p.Id == id);
        }

        private static List<Product> s_products = new List<Product>();
        private static int s_id;
    }
}
