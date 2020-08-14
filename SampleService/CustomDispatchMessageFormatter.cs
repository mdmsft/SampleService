using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace SampleService
{
    public class CustomDispatchMessageFormatter : IDispatchMessageFormatter
    {
        private readonly IDispatchMessageFormatter dispatchMessageFormatter;

        public CustomDispatchMessageFormatter(IDispatchMessageFormatter dispatchMessageFormatter)
        {
            this.dispatchMessageFormatter = dispatchMessageFormatter;
        }

        public void DeserializeRequest(Message message, object[] parameters)
        {
            var thread = new Thread(() =>
            {
                Factorial(1024).Wait();
                dispatchMessageFormatter.DeserializeRequest(message, parameters);
            }, 1024 * 1024);
            thread.Start();
            thread.Join();
        }

        public Message SerializeReply(MessageVersion messageVersion, object[] parameters, object result)
        {
            Message message = default;
            var thread = new Thread(() =>
            {
                Factorial(1024).Wait();
                message = dispatchMessageFormatter.SerializeReply(messageVersion, parameters, result);
            }, 1024 * 1024);
            thread.Start();
            thread.Join();
            return message;
        }

        private static async Task<long> Factorial(long n)
        {
            Debug.WriteLine(n);
            if (n > 0)
            {
                return n * await Factorial(n - 1);
            }
            return n;
        }
    }
}