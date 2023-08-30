using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    internal class Weather
    {
        // member variables (HAS A)
        public int ActualTemp;
        public string ForecastedTemp;
        public string ActualCondition;
        public string TodaysForecast;
        private List<string> PredictedWeatherForecasts;
        private List<string> ActualWeatherConditions;
        private Random rndm;
        // constructor (SPAWNER)
        public Weather()
        {
            PredictedWeatherForecasts = new List<string>() { "sunny", "stormy", "freezing", "windy" };
            ActualWeatherConditions = new List<string>() { "sunny", "stormy", "freezing", "windy" };
            rndm = new Random();
            TodaysForecast = PredictedWeatherForecasts[rndm.Next(PredictedWeatherForecasts.Count)];

        }

        // member methods (CAN DO)

        public string GenerateWeatherCondition()
        {
            for (int i = 0; i < PredictedWeatherForecasts.Count; i++)
            {
                ActualWeatherConditions.Add(TodaysForecast);
            }
            ActualCondition = ActualWeatherConditions[rndm.Next(ActualWeatherConditions.Count)];
            return ActualCondition;    
        }
        public void GenerateTemperature()
        {
            if (ActualCondition == "sunny" || ActualCondition == "windy")
            {
                ActualTemp = rndm.Next(69, 90);
            }
            else if (ActualCondition == "stormy")
            {
                ActualTemp = rndm.Next(40, 85);
            }
            else
            {
                ActualTemp = rndm.Next(28, 35);
            }
        }
        public void ForecastTemp()
        {
            List<string> warmTemps = new List<string> { "low 70s", "mid 70s", "high 70s", "low 80s", "mid 80s", "high 80s" };
            List<string> coldTemps = new List<string> { "low 50s", "mid 40s", "high 50s", "low 60s", "mid 50s", "high 40s" };
            List<string> allTemps = new List<string> {
                "low 70s", "mid 70s", "high 70s", "low 80s", "mid 80s", "high 80s",
                "low 50s", "mid 40s", "high 50s", "low 60s", "mid 50s", "high 40s" };
            
            if (TodaysForecast == "sunny")
            {
                ForecastedTemp = warmTemps[rndm.Next(warmTemps.Count)];    
            }
            else if (TodaysForecast == "stormy" || TodaysForecast == "windy")
            {
                ForecastedTemp = allTemps[rndm.Next(allTemps.Count)];
            }
            else
            {
                ForecastedTemp = "30s";
            }

        }
    }
}
