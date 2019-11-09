using DarkSkyApiConsumer.Models;
using DarkSkyApiConsumer.Services;
using Newtonsoft.Json;

using System.Linq;
using System.Threading.Tasks;

using System.Web.Configuration;
using System.Web.Mvc;

namespace DarkSkyApiConsumer.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {            
            return View();
        }

        public async Task<JsonResult> GetWeatherData(float latitude, float longitude)
        {        
            var rootUrl = WebConfigurationManager.AppSettings["DarkSkyBaseUrl"];
            var apiKey = WebConfigurationManager.AppSettings["DarkSkyApiKey"];

            var queryString = $"{rootUrl}/{apiKey}/{latitude},{longitude}";

            var rawWeatherData = await DarkSkyService.getDataFromService(queryString);
            var weatherData = JsonConvert.DeserializeObject<Rootobject>(rawWeatherData);

            var weatherViewModel = new WeatherViewModel();
            weatherViewModel.Currently = weatherData.currently;

            weatherViewModel.Daily.data = weatherData.daily.data.Take(8).ToArray();
            weatherViewModel.Daily.summary = weatherData.daily.summary;

            weatherViewModel.Hourly.data = weatherData.hourly.data.Take(8).ToArray();
            weatherViewModel.Hourly.summary = weatherData.hourly.summary;
            
            return Json(weatherViewModel);
        }
    }
}