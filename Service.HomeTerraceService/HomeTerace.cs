using System.Threading;
using Raspberry.IO.GeneralPurpose;

using log4net;
using log4net.Config;

namespace Service
{
    public class HomeTerace : IHomeTerraceService
    {

		private static readonly ILog logger = 
			LogManager.GetLogger(typeof(HomeTerace));

		static HomeTerace(){

			DOMConfigurator.Configure ();	
			logger.Info ("Starting service configuring.");
		}
    
        public string Greet(string name)
        {
            var led1 = ConnectorPin.P1Pin11.Output();

            var connection = new GpioConnection(led1);

            for (var i = 0; i < 10; i++)
            {
                connection.Toggle(led1);
                Thread.Sleep(250);
            }

			logger.Info ("Greet: Done.");

            connection.Close();

            return "Hello " + name;
        }

        public bool StartWatering(int interval)
        {
            var led1 = ConnectorPin.P1Pin11.Output();
            var connection = new GpioConnection(led1);
            connection[led1] = true;
            connection.Close();

			logger.Info ("StartWatering: Done.");

            return true;
        }

        public bool StopWatering()
        {
            var led1 = ConnectorPin.P1Pin11.Output();
            var connection = new GpioConnection(led1);
            connection[led1] = false;
            connection.Close();

			logger.Info ("StopWatering: Done.");

            return true;
        }

        public string ReadWateringState()
        {
            var pin = ConnectorPin.P1Pin12.ToProcessor();
            var driver = GpioConnectionSettings.DefaultDriver;

            driver.Allocate(pin, PinDirection.Input);
            pin.Input().PullUp();
            var state = driver.Read(pin);
            driver.Release(pin);

			logger.Info ("ReadWateringState: Done.");

            return state ? "ON" : "OFF";

        }

        public int CheckWaterTankLevel()
        {
            var pin = ConnectorPin.P1Pin13.ToProcessor();
            var driver = GpioConnectionSettings.DefaultDriver;

            driver.Allocate(pin, PinDirection.Input);
            pin.Input().PullUp();
            var state = driver.Read(pin);
            driver.Release(pin);

			logger.Info ("CheckWaterTankLevel: Done.");

            return state ? 50 : 100;

        }
    }
}