using System.ServiceModel;

namespace Service
{
	[ServiceContract]
	public interface IHomeTerraceService
	{
		[OperationContract]
		string Greet (string name);
		bool StartWatering (int interval);
		bool StopWatering ();
		string ReadWateringState();
		int CheckWaterTankLevel();
	}
}
