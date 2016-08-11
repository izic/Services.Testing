﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Service;

namespace Host
{
    partial class HomeTerraceWindowsService : ServiceBase
    {
 public ServiceHost _serviceHost = null;
        public HomeTerraceWindowsService()
        {
            // Name the Windows Service
            ServiceName = "WCFHomeTerraceWindowsService";
        }

        public static void Main()
        {
            ServiceBase.Run(new HomeTerraceWindowsService());
        }

        // Start the Windows service.
        protected override void OnStart(string[] args)
        {
            if (_serviceHost != null)
            {
                _serviceHost.Close();
            }

            // Register types with Unity
            using (IUnityContainer container = new UnityContainer())
            {
                RegisterTypes(container);

                // Step 1 Create a URI to serve as the base address.
                var baseAddress = new Uri("http://localhost:8090");
                var binding = new BasicHttpBinding();

                // Step 2 Create a ServiceHost instance
                _serviceHost = new UnityServiceHost(container,
                    typeof(HomeTerraceService), baseAddress);

                try
                {
                    // Step 3 Add a service endpoint.
                    _serviceHost.AddServiceEndpoint(typeof(IHomeTerraceService), binding, baseAddress);
                    // Step 4 Enable metadata exchange.
                    var smb = new ServiceMetadataBehavior();
                    smb.HttpGetEnabled = true;
                    _serviceHost.Description.Behaviors.Add(smb);
                    // Step 5 Start the service.
                    _serviceHost.Open();
               }
                catch (CommunicationException ce)
                {
                    //Log this: Console.WriteLine("An exception occurred: {0}", ce.Message);
                    _serviceHost.Abort();
                }
            }
        }

        protected override void OnStop()
        {
            if (_serviceHost != null)
            {
                _serviceHost.Close();
                _serviceHost = null;
            }
        }

        private static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType(typeof(IHomeTerraceService), typeof(HomeTerace));
            container.RegisterType<HomeTerraceService>(new InjectionConstructor(container.Resolve<IHomeTerraceService>()));
        }
    }
}