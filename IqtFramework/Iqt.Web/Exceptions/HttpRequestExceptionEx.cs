using System;
using System.Net.Http;

namespace Iqt.Web.Exceptions
{
    public class HttpRequestExceptionEx : HttpRequestException
    {
        /// <summary>
        /// Constructor with a request status code
        /// </summary>
        public System.Net.HttpStatusCode HttpCode { get; }
        public HttpRequestExceptionEx(System.Net.HttpStatusCode code) : this(code, null, null)
        {
        }

        /// <summary>
        /// Constructor with a a status code and a error message
        /// </summary>
        /// <param name="code">The request status code</param>
        /// <param name="message">The error message</param>
        public HttpRequestExceptionEx(System.Net.HttpStatusCode code, string message) : this(code, message, null)
        {
        }

        /// <summary>
        /// Constructor with a a status code, a error message and a inner exception
        /// </summary>
        /// <param name="code">The request status code</param>
        /// <param name="message">The error message</param>
        /// <param name="inner">The inner exception</param>
        public HttpRequestExceptionEx(System.Net.HttpStatusCode code, string message, Exception inner) : base(message,
            inner)
        {
            HttpCode = code;
        }

    }
}
