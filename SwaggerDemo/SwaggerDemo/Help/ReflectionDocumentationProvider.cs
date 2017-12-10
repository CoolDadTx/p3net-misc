using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Web.Http.Controllers;
using System.Web.Http.Description;
using Swashbuckle.Application;
using Swashbuckle.Swagger;

namespace SwaggerDemo.Help
{
    /// <summary>
    /// A custom <see cref="IDocumentationProvider"/> that uses Reflection for the API documentation.
    /// </summary>
    public class ReflectionDocumentationProvider : IDocumentationProvider, IOperationFilter, IModelFilter
    {
        public static readonly ReflectionDocumentationProvider Default = new ReflectionDocumentationProvider();

        public string GetDocumentation(HttpControllerDescriptor controllerDescriptor)
        {
            return controllerDescriptor.ControllerType.GetDescription();
        }

        public virtual string GetDocumentation(HttpActionDescriptor actionDescriptor)
        {
            return GetMethod(actionDescriptor).GetDescription();
        }

        public virtual string GetDocumentation(HttpParameterDescriptor parameterDescriptor)
        {
            var attr = parameterDescriptor.ActionDescriptor?.GetCustomAttributes<RestParameterAttribute>().FirstOrDefault(a => String.Compare(a.Name, parameterDescriptor.ParameterName, true) == 0);
            if (attr != null)
                return attr.Description;

            var reflectedParameterDescriptor = parameterDescriptor 
                                                    as ReflectedHttpParameterDescriptor;

            return reflectedParameterDescriptor.ParameterInfo.GetDescription();            
        }

        public string GetResponseDocumentation(HttpActionDescriptor actionDescriptor)
        {
            var attr = actionDescriptor.GetCustomAttributes<RestResponseAttribute>().FirstOrDefault();
            if (attr != null)
                return attr.Description;

            var returnInfo = GetMethod(actionDescriptor);
            if (returnInfo == null)
                return null;            

            return returnInfo.ReturnTypeCustomAttributes.GetDescription();
        }

        public string GetDocumentation(MemberInfo member)
        {
            return member.GetDescription();
        }

        public string GetDocumentation ( Type type )
        {
            return type.GetDescription();
        }

        #region IOperationFilter Members

        public void Apply ( Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription )
        {
            operation.summary = GetDocumentation(apiDescription.ActionDescriptor);

            //Parameters
            if (operation.parameters != null)
            {
                foreach (var parameter in apiDescription.ParameterDescriptions)
                {
                    var opParam = operation.parameters.FirstOrDefault(p => String.Compare(p.name, parameter.Name, true) == 0);
                    if (opParam != null)
                        opParam.description = GetDocumentation(parameter.ParameterDescriptor);
                };
            };

            //Return value
            if (apiDescription.ActionDescriptor.ReturnType != null)
            {
                operation.responses.Clear();

                operation.responses["200"] = new Response()
                {
                    description = GetResponseDocumentation(apiDescription.ActionDescriptor),
                    schema = new Schema()
                    {
                        @ref = apiDescription.ActionDescriptor.ReturnType.FullName
                    }
                };
            };
        }
        #endregion

        #region IModelFilter Members

        public void Apply ( Schema model, ModelFilterContext context )
        {
            model.description = GetDocumentation(context.SystemType);

            //Properties
            model.properties.Clear();
            foreach (var property in context.SystemType.GetProperties())
            {
                model.properties[property.Name] = new Schema()
                {
                    description = GetDocumentation(property)
                };
            };
        }
        #endregion

        #region Private Members

        private MethodInfo GetMethod(HttpActionDescriptor actionDescriptor)
        {
            var reflectedActionDescriptor = actionDescriptor as ReflectedHttpActionDescriptor;
            if (reflectedActionDescriptor != null)
                return reflectedActionDescriptor.MethodInfo;
            
            return null;
        }
        #endregion
    }

    public static class CustomAttributeProviderExtensions
    {
        public static T GetAttribute<T> ( this ICustomAttributeProvider source ) 
                                            where T : Attribute
        {
            if (source == null)
                return null;

            var attrs = source.GetCustomAttributes(typeof(T), true);

            return (attrs != null) ? attrs.OfType<T>().FirstOrDefault() : null;
        }

        public static string GetDescription ( this ICustomAttributeProvider source )
        {
            if (source == null)
                return null;

            var attr = source.GetAttribute<DescriptionAttribute>();

            return (attr != null) ? attr.Description : null;
        }
    }

    internal static class SwaggerConfigExtensions
    {
        public static SwaggerDocsConfig UseReflectionDocumentation ( this SwaggerDocsConfig source )
        {
            source.OperationFilter(() => ReflectionDocumentationProvider.Default);

            //HACK: This is a hack to get access to the model filters because it isn't public
            //source.ModelFilters<ReflectionDocumentationProvider>();
            var modelFilters = source.GetType().GetField("_modelFilters", BindingFlags.NonPublic | BindingFlags.IgnoreCase | BindingFlags.Instance);
            var filters = modelFilters?.GetValue(source) as System.Collections.Generic.IList<Func<IModelFilter>>;
            if (filters != null)
            {
                filters.Add(() => ReflectionDocumentationProvider.Default);
            } else
                Debug.WriteLine("Unable to get model filters from SwaggerDocsConfig, model documentation will be unavailable.");

            return source;
        }
    }
}
