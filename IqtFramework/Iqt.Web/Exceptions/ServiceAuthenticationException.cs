using System;

namespace Iqt.Web.Exceptions
{
    /// <summary>
    /// The exception that is thrown when service authentication error occurs
    /// </summary>
    public class ServiceAuthenticationException : Exception
    {
        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public ServiceAuthenticationException()
        {
        }

        /// <summary>
        /// Content Constructor
        /// </summary>
        /// <param name="content">The content of the error message</param>
        public ServiceAuthenticationException(string content)
        {
            Content = content;
        }

        #endregion

        /// <summary>
        /// The content of the error
        /// </summary>
        public string Content { get; }
    }
}
