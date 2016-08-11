using System.ServiceModel;

namespace Service
{
	[ServiceContract]
	public interface IHomeTerraceService
	{
		[OperationContract]
		string Greet (string name);
		[OperationContract]
		bool StartWatering (int interval);
		[OperationContract]
		bool StopWatering ();
		[OperationContract]
		string ReadWateringState();
		[OperationContract]
		int CheckWaterTankLevel();
	}
}
