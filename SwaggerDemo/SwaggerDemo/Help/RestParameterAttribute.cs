using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SwaggerDemo.Help
{
    /// <summary>Provides documentation for a REST parameter.</summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class RestParameterAttribute : Attribute
    {
        /// <summary>Initializes an instance of the <see cref="RestParameterAttribute"/> class.</summary>
        /// <param name="name">The parameter name.</param>
        /// <param name="description">The description.</param>
        public RestParameterAttribute ( string name, string description )
        {
            Name = name ?? "";
            Description = description ?? "";
        }

        /// <summary>Gets the description of the parameter.</summary>
        public string Description { get; private set; }

        /// <summary>Gets the name of the parameter.</summary>
        public string Name { get; private set; }        
    }
}