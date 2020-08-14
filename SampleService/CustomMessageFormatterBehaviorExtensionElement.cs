using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Configuration;
using System.Web;

namespace SampleService
{
    public class CustomMessageFormatterBehaviorExtensionElement : BehaviorExtensionElement
    {
        public override Type BehaviorType => typeof(CustomMessageFormatterEndpointBehavior);

        protected override object CreateBehavior()
        {
            return new CustomMessageFormatterEndpointBehavior();
        }
    }
}