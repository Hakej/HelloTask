using System;

namespace HelloTask.Core.Domain
{
    public abstract class HelloTaskException : Exception
    {
        public string Code { get; }

        protected HelloTaskException()
        {
            
        }
        
        public HelloTaskException(string code)
        {
            
        }
        
        public HelloTaskException(string message, params object[] args) : this(string.Empty, message, args)
        {
        }
        
        public HelloTaskException(string code, string message, params object[] args) : this(null, string.Empty, message, args)
        {
        }
        
        public HelloTaskException(Exception innerException, string message, params object[] args) 
            : this(innerException, string.Empty, message, args)
        {
        }
        
        public HelloTaskException(Exception innerException, string code, string message, params object[] args) 
            : base(string.Format(message, args), innerException)
        {
            Code = code;
        }
    }
}