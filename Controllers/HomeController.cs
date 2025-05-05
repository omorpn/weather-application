using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using weather_application.Model;

namespace weather_application.Controllers
{
    [Route("/")]
    public class HomeController : Controller
    {
        public List<CityWeather> cityWeather = new List<CityWeather>()
            {
                new CityWeather(cityUniqueCode : "LDN", cityName : "London", dateAndTime :  DateTime.Parse("2030-01-01 8:00"),  temperatureFahrenheit : 33),
                new CityWeather(cityUniqueCode : "NYC", cityName : "London", dateAndTime : DateTime.Parse("2030-01-01 3:00"),  temperatureFahrenheit : 60),
                new CityWeather(cityUniqueCode : "PAR", cityName : "Paris", dateAndTime : DateTime.Parse("2030-01-01 9:00"),  temperatureFahrenheit : 82)
            };
        public IActionResult Index()
        {
            if (cityWeather.Count > 0)
            {
                return View(cityWeather);

            }

            return View("error");

        }
        [HttpGet("/weather/{cityCode:regex(^[[A-Za-z]]{{2,}}$)}")]
        public IActionResult GetCityByCode(string cityCode)
        {
            if (!string.IsNullOrEmpty(cityCode))
            {
                var cit = from city in cityWeather
                          where city.CityUniqueCode.ToLower() == cityCode.ToLower()
                          select city;
                var cityById = cityWeather.Where(city => city.CityUniqueCode.ToLower() 
                == cityCode.ToLower()).FirstOrDefault();
                if(cityById != null)
                {
                return View("CityWeather", cityById);

                }
                else
                {

                    return View("error", cityById);
                }

            }
            return Index();
        }
    }
}
