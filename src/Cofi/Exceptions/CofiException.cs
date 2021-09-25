using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Cofi.Exceptions
{
    public class CofiException : Exception
    {
        private readonly Dictionary<string, object> _contextData = new();
        private readonly StringBuilder _clientMessageBuilder = new();

        public IDictionary<string, object> ContextData
        {
            get 
            {
                SetContextData(_contextData);
                return _contextData;
            }
        }

        public string ClientMessage
        {
            get
            {
                SetClientMessage(_clientMessageBuilder);
                return _clientMessageBuilder.ToString();
            }
        }

        public CofiException()
        {
        }

        public CofiException(string? message) : base(message)
        {
        }

        public CofiException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected CofiException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        protected virtual void SetContextData(IDictionary<string, object> contextData)
        {
        }

        protected virtual void SetClientMessage(StringBuilder clientMessageBuilder)
        {
        }
    }
}