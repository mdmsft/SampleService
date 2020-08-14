using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Web;

namespace SampleService
{
    public class CustomMessageFormatterEndpointBehavior : IEndpointBehavior
    {
        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
            
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            foreach (var operation in endpoint.Contract.Operations)
            {
                operation.OperationBehaviors.Add(new CustomMessageFormatterOperationBehavior());
            }
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            foreach (var operation in endpoint.Contract.Operations)
            {
                operation.OperationBehaviors.Add(new CustomMessageFormatterOperationBehavior());
            }
        }

        public void Validate(ServiceEndpoint endpoint)
        {
            
        }
    }
}