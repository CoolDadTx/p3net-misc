using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SwaggerDemo.Help
{
    /// <summary>Provides documentation for a REST response.</summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class RestResponseAttribute : Attribute
    {
        /// <summary>Initializes an instance of the <see cref="RestResponseAttribute"/> class.</summary>
        /// <param name="description">The description.</param>
        public RestResponseAttribute ( string description ) : this(description, null)
        {
        }

        /// <summary>Initializes an instance of the <see cref="RestResponseAttribute"/> class.</summary>
        /// <param name="description">The description.</param>
        /// <param name="responseType">The response type.</param>
        public RestResponseAttribute ( string description, Type responseType )
        {
            Description = description ?? "";
            Type = responseType;
        }

        /// <summary>Gets the description of the response.</summary>
        public string Description { get; private set; } 

        /// <summary>Gets the type of the response.</summary>
        public Type Type { get; private set; }
    }
}