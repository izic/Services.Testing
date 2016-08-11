using System;
using System.ServiceModel;
using Microsoft.Practices.Unity;

namespace Host
{
    public class UnityServiceHost : ServiceHost
    {
        public UnityServiceHost(IUnityContainer container,
            Type serviceType, params Uri[] baseAddresses)
            : base(serviceType, baseAddresses)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }
            foreach (var cd in ImplementedContracts.Values)
            {
                cd.Behaviors.Add(new UnityInstanceProvider(container));
            }
        }
    }
}

