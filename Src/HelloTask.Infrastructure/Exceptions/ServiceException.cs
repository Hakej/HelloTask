using System;
using HelloTask.Core.Domain;

namespace HelloTask.Infrastructure.Exceptions
{
    public class ServiceException : HelloTaskException
    {
        protected ServiceException() 
        {
            
        }
        
        public ServiceException(string code) : base(code)
        {
            
        }
        
        public ServiceException(string message, params object[] args) : base(string.Empty, message, args)
        {
        }
        
        public ServiceException(string code, string message, params object[] args) : base(null, string.Empty, message, args)
        {
        }
        
        public ServiceException(Exception innerException, string message, params object[] args) 
            : base(innerException, string.Empty, message, args)
        {
        }
        
        public ServiceException(Exception innerException, string code, string message, params object[] args) 
            : base(code, string.Format(message, args), innerException)
        {
        }
    }
}