using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;

namespace CustomFilterFactory.Filters
{
    /// <summary>
    /// LogFilter
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Filters.IActionFilter" />
    public class LogFilter : IActionFilter
    {
        private readonly ILogger<LogFilter> _logger;
        private const string _defaultMessageActionExecution = "Default Message for Action Execution";
        private const string _defaultMessageActionExecuting = "Default Message for Action Executing";
        public string CustomActionExecutionMessage { get; set; } = _defaultMessageActionExecution;
        public string CustomActionExecutedMessage { get; set; } = _defaultMessageActionExecuting;

        /// <summary>
        /// Initializes a new instance of the <see cref="LogFilter"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public LogFilter(ILogger<LogFilter> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Called after the action executes, before the action result.
        /// </summary>
        /// <param name="context">The <see cref="T:Microsoft.AspNetCore.Mvc.Filters.ActionExecutedContext" />.</param>
        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation($"Before {CustomActionExecutionMessage} action executed");
        }

        /// <summary>
        /// Called before the action executes, after model binding is complete.
        /// </summary>
        /// <param name="context">The <see cref="T:Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext" />.</param>
        public void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation($"After {CustomActionExecutedMessage} action executing");
        }
    }
}
