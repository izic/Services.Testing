using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using Service;

namespace Client
{
	public class MyServiceClient : ClientBase<IHomeTerraceService>, IHomeTerraceService
	{
		public MyServiceClient (Binding binding, EndpointAddress address) : base (binding, address)
		{
		}

		public string Greet (string name)
		{
			return Channel.Greet (name);
		}

		public bool StartWatering (int interval)
		{
			return Channel.StartWatering (interval);
		}

		public bool StopWatering ()
		{
			return Channel.StopWatering ();
		}

		public string ReadWateringState ()
		{
			return Channel.ReadWateringState ();
		}

		public int CheckWaterTankLevel ()
		{
			return Channel.CheckWaterTankLevel ();
		}



	}
}