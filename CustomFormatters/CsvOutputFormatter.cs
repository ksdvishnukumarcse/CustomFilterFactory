using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApi.Entities;

namespace ContentNegotiation.CustomFormatters
{
    /// <summary>
    /// CsvOutputFormatter
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Formatters.TextOutputFormatter" />
    public class CsvOutputFormatter : TextOutputFormatter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CsvOutputFormatter"/> class.
        /// </summary>
        public CsvOutputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/csv"));
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }

        protected override bool CanWriteType(Type type)
        {
            if (typeof(User).IsAssignableFrom(type) || typeof(IEnumerable<User>).IsAssignableFrom(type))
            {
                return base.CanWriteType(type);
            }
            return false;
        }

        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            var response = context.HttpContext.Response;
            var buffer = new StringBuilder();
            if (context.Object is IEnumerable<User>)
            {
                foreach (var user in (IEnumerable<User>)context.Object)
                {
                    FormatCsv(buffer, user);
                }
            }
            else
            {
                FormatCsv(buffer, (User)context.Object);
            }
            await response.WriteAsync(buffer.ToString());
        }

        private static void FormatCsv(StringBuilder buffer, User user)
        {
            buffer.AppendLine($"{user.Id},\"{user.FirstName},\"{user.LastName},\"{user.Username},\"{user.Password}\"");
        }
    }
}
