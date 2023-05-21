namespace CarReservation.API.Extensions
{
    public class CarIdGenerator
    {
        private int _carIdCounter = 1;

        public string GenerateCarId()
        {
            string carId = "C" + _carIdCounter.ToString();
            _carIdCounter++;
            return carId;
        }
    }
}
  