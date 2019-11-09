using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DarkSkyApiConsumer.Models
{
    public class WeatherViewModel
    {
        public Daily Daily = new Daily();
        public Currently Currently = new Currently();
        public Hourly Hourly = new Hourly();
    }
}