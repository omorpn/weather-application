namespace weather_application.Model
{
    public class CityWeather
    {
        public string CityUniqueCode { get; set; }
        public string CityName { get; set; }

        public DateTime DateAndTime { get; set; }

        public int TemperatureFahrenheit { get; set; }
        public CityWeather(string cityUniqueCode, string cityName, DateTime dateAndTime, int temperatureFahrenheit)
       => (CityUniqueCode, CityName, DateAndTime, TemperatureFahrenheit)
            = (cityUniqueCode, cityName, dateAndTime, temperatureFahrenheit);
    }

}
