using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace CustomFilterFactory.Filters
{
    /// <summary>
    /// LogFilterFactory
    /// </summary>
    /// <seealso cref="System.Attribute" />
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Filters.IFilterFactory" />
    public class LogFilterFactory : Attribute, IFilterFactory
    {
        public string CustomActionExecutionMessage { get; set; }
        public string CustomActionExecutedMessage { get; set; }
        public bool IsReusable => false;

        /// <summary>
        /// Creates an instance of the executable filter.
        /// </summary>
        /// <param name="serviceProvider">The request <see cref="T:System.IServiceProvider" />.</param>
        /// <returns>
        /// An instance of the executable filter.
        /// </returns>
        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
        {
            var filter = (LogFilter)serviceProvider.GetService(typeof(LogFilter));

            if (!string.IsNullOrWhiteSpace(CustomActionExecutionMessage))
            {
                filter.CustomActionExecutionMessage = CustomActionExecutionMessage;
            }

            if (!string.IsNullOrWhiteSpace(CustomActionExecutedMessage))
            {
                filter.CustomActionExecutedMessage = CustomActionExecutedMessage;
            }
            return filter;
        }
    }
}
