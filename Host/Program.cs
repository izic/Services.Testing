using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using Microsoft.Practices.Unity;
using Service;

namespace Host
{
    internal class MainClass
    {
       //private static void Main(string[] args)
       // {
       //     // Register types with Unity
       //     using (IUnityContainer container = new UnityContainer())
       //     {
       //         RegisterTypes(container);

       //         // Step 1 Create a URI to serve as the base address.
       //         var baseAddress = new Uri("http://localhost:8090");
       //         var binding = new BasicHttpBinding();

       //         // Step 2 Create a ServiceHost instance
       //         ServiceHost selfHost = new UnityServiceHost(container,
       //             typeof (HomeTerraceService), baseAddress);

       //         try
       //         {
       //             // Step 3 Add a service endpoint.
       //             selfHost.AddServiceEndpoint(typeof (IHomeTerraceService), binding, baseAddress);
       //             // Step 4 Enable metadata exchange.
       //             var smb = new ServiceMetadataBehavior();
       //             smb.HttpGetEnabled = true;
       //             selfHost.Description.Behaviors.Add(smb);
       //             // Step 5 Start the service.
       //             selfHost.Open();

       //             Console.WriteLine("The service is ready.");
       //             Console.WriteLine("Press <ENTER> to terminate service.");
       //             Console.WriteLine();
       //             Console.ReadLine();
       //             // Close the ServiceHostBase to shutdown the service.
       //             selfHost.Close();
       //         }
       //         catch (CommunicationException ce)
       //         {
       //             Console.WriteLine("An exception occurred: {0}", ce.Message);
       //             selfHost.Abort();
       //         }
       //     }
       // }

       // private static void RegisterTypes(IUnityContainer container)
       // {
       //     container.RegisterType(typeof (IHomeTerraceService), typeof (HomeTeraceDummy));
       //     container.RegisterType<HomeTerraceService>(new InjectionConstructor(container.Resolve<IHomeTerraceService>()));
       // }
    }

}