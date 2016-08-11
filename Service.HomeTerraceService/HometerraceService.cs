using Microsoft.Practices.Unity;
using Raspberry.IO.GeneralPurpose;

namespace Service
{
	public class HomeTerraceService : IHomeTerraceService
	{
	    private IHomeTerraceService _implementation;

	    public HomeTerraceService()
	    {
	        _implementation = new UnityContainer().Resolve<IHomeTerraceService>();
	    }

	    public HomeTerraceService(IHomeTerraceService implemetation)
	    {
	        _implementation = implemetation;
	    }

		public string Greet (string name)
		{
		    return _implementation.Greet(name);
		}
	    

	    public bool StartWatering (int interval)
		{
            return _implementation.StartWatering(interval);
		}

		public bool StopWatering ()
		{
			return _implementation.StopWatering();
		}

		public string ReadWateringState ()
		{
            return _implementation.ReadWateringState();
		}

		public int CheckWaterTankLevel ()
		{
            return _implementation.CheckWaterTankLevel();
		}
	
	}
}