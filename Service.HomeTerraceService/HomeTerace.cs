using System.Threading;
using Raspberry.IO.GeneralPurpose;

namespace Service
{
    public class HomeTerace : IHomeTerraceService
    {
    
        public string Greet(string name)
        {
            var led1 = ConnectorPin.P1Pin11.Output();

            var connection = new GpioConnection(led1);

            for (var i = 0; i < 10; i++)
            {
                connection.Toggle(led1);
                Thread.Sleep(250);
            }


            connection.Close();

            return "Hello " + name;
        }

        public bool StartWatering(int interval)
        {
            var led1 = ConnectorPin.P1Pin11.Output();
            var connection = new GpioConnection(led1);
            connection[led1] = true;
            connection.Close();
            return true;
        }

        public bool StopWatering()
        {
            var led1 = ConnectorPin.P1Pin11.Output();
            var connection = new GpioConnection(led1);
            connection[led1] = false;
            connection.Close();
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

            return state ? 50 : 100;

        }
    }
}