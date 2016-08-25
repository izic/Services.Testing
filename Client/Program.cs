// Client
using System;
using System.ServiceModel;

using log4net;
using log4net.Config;

namespace Client
{
	public class Program
	{

		private static readonly ILog logger = 
			LogManager.GetLogger(typeof(Program));

		static Program()
		{
			DOMConfigurator.Configure();
		}

		public static void Main (string[] args)
		{
			logger.Info ("Client app starting");

			Console.WriteLine ("WCF Client\n");
			string name = "";
			var binding = new BasicHttpBinding ();
			var address = new EndpointAddress ("http://localhost:8090");
			var client = new MyServiceClient (binding, address);


			while (true) {
				Console.Write("\nEnter Command (Start/Stop/{empty string for Greet}): ");
				var command = Console.ReadLine ();

				if (string.IsNullOrWhiteSpace (command)) {
					Console.Write("\nEnter name: ");
					name = Console.ReadLine ();
					Console.WriteLine ("Service response: " + client.Greet (name));
				} else {					
					name = Console.ReadLine ();
					switch (command.ToLower().Trim()) {
					case "start":
						Console.WriteLine ("Service response: " + client.StartWatering(5));
						break;

					case "stop":
						Console.WriteLine ("Service response: " + client.StopWatering());
						break;
					}

				}
			}
		}
	}
}

