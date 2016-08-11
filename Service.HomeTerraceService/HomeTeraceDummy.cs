using System.Diagnostics;
using System.Threading;
using Raspberry.IO.GeneralPurpose;

namespace Service
{
    public class HomeTeraceDummy :IHomeTerraceService
    {
        public HomeTeraceDummy()
        {
        }
    
        public string Greet(string name)
        {  
            return "Hello " + name;
        }

        public bool StartWatering(int interval)
        {
            Debug.WriteLine("Start Watering");
            return true;
        }

        public bool StopWatering()
        {
            Debug.WriteLine("Stop Watering");
            return true;
        }

        public string ReadWateringState()
        {
            Debug.WriteLine("Read Watering State");
            return "On";
        }

        public int CheckWaterTankLevel()
        {
            Debug.WriteLine("Check Water Tank Level");
            return 0;
        }
    }
}