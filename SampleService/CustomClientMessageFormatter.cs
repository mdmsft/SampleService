using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Web;

namespace SampleService
{
    public class CustomClientMessageFormatter : IClientMessageFormatter
    {
        private readonly IClientMessageFormatter clientMessageFormatter;

        public CustomClientMessageFormatter(IClientMessageFormatter clientMessageFormatter)
        {
            this.clientMessageFormatter = clientMessageFormatter;
        }

        public object DeserializeReply(Message message, object[] parameters)
        {
            return clientMessageFormatter.DeserializeReply(message, parameters);
        }

        public Message SerializeRequest(MessageVersion messageVersion, object[] parameters)
        {
            return clientMessageFormatter.SerializeRequest(messageVersion, parameters);
        }
    }
}