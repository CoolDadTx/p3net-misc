using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Swashbuckle.Swagger;

namespace SwaggerDemo.Help
{
    /// <summary>Provides caching for Swagger documentation.</summary>
    internal class CachingSwaggerProvider : ISwaggerProvider
    {
        public CachingSwaggerProvider ( ISwaggerProvider defaultProvider )
        {
            m_defaultProvider = defaultProvider;
        }

        public SwaggerDocument GetSwagger ( string rootUrl, string apiVersion )
        {
            var cacheKey = $"SwaggerDoc-{apiVersion}";

            //Check cache first
            var doc = HttpRuntime.Cache.Get(cacheKey) as SwaggerDocument;
            if (doc == null)
            {
                doc = m_defaultProvider.GetSwagger(rootUrl, apiVersion);
                HttpRuntime.Cache[cacheKey] = doc;
            };

            return doc;
        }

        private readonly ISwaggerProvider m_defaultProvider;        
    }
}