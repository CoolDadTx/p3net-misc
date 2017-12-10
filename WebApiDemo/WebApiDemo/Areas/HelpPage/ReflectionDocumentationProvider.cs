using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Web.Http.Controllers;
using System.Web.Http.Description;

using WebApiDemo.Areas.HelpPage.ModelDescriptions;

namespace P3Net.Web.Http.Description
{
    /// <summary>
    /// A custom <see cref="IDocumentationProvider"/> that uses Reflection for the API documentation.
    /// </summary>
    public class ReflectionDocumentationProvider : IDocumentationProvider
                                                    , IModelDocumentationProvider
    {        
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
            var reflectedParameterDescriptor = parameterDescriptor 
                                                    as ReflectedHttpParameterDescriptor;

            return reflectedParameterDescriptor.ParameterInfo.GetDescription();            
        }

        public string GetResponseDocumentation(HttpActionDescriptor actionDescriptor)
        {
            var returnInfo = GetMethod(actionDescriptor);
            if (returnInfo == null)
                return null;

            return returnInfo.ReturnTypeCustomAttributes.GetDescription();
        }

        public string GetDocumentation(MemberInfo member)
        {
            return member.GetDescription();
        }

        public string GetDocumentation(Type type)
        {
            return type.GetDescription();            
        }

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
}
