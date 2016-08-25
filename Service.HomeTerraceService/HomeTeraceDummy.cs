using System.Diagnostics;
using System.Threading;

using log4net;
using log4net.Config;

namespace Service
{
    public class HomeTeraceDummy :IHomeTerraceService
    {

		private static readonly ILog logger = 
			LogManager.GetLogger(typeof(HomeTeraceDummy));

		static HomeTeraceDummy(){

			DOMConfigurator.Configure ();	
			logger.Info ("Starting service configuring.");
		}

        public HomeTeraceDummy()
        {
			logger.Info ("Starting service constructor.");
        }
    
        public string Greet(string name)
        {  
			logger.Info ("Greet: Hello" + name);
            return "Hello " + name;
        }

        public bool StartWatering(int interval)
        {
            //Debug.WriteLine("Start Watering");
			logger.Info ("Start Watering");
            return true;
        }

        public bool StopWatering()
        {
            //Debug.WriteLine("Stop Watering");
			logger.Info ("Stop Watering");
            return true;
        }

        public string ReadWateringState()
        {
            //Debug.WriteLine("Read Watering State");
			logger.Info ("Read Watering State");
            return "On";
        }

        public int CheckWaterTankLevel()
        {
            //Debug.WriteLine("Check Water Tank Level");
			logger.Info ("Check Water Tank Level");
            return 0;
        }
    }
}