using WeatherFinal.Components.Models;

namespace WeatherFinal.Components.Service
{
    public class WeatherForecastService
    {
        public async Task<List<WeatherForecast>> GetForecastAsync(string city)
        {
            //------------------------------------------------------------------------------------------------------

            //openweather API

            string your_api_key = "0ef163157c35d4eb8b15a898120f8b77";
            HttpClient cl = new HttpClient() { BaseAddress = new Uri("http://api.openweathermap.org") };
            var response = await cl.GetFromJsonAsync<Root>($"/data/2.5/weather?q={city}&appid={your_api_key}");


            //------------------------------------------------------------------------------------------------------

            // weatherAPI




            //string your_api_key = "YOUR API";
            //HttpClient cl = new HttpClient() { BaseAddress = new Uri("http://api.weatherapi.com") };
            //var response = await cl.GetFromJsonAsync<Root>($"/v1/forecast.json?key={your_api_key}&q={city}&days=1");

            //---------------------------------------------------------------------------------------------------------

            var output = new List<WeatherForecast>();

            //-----------------------------------------------------------------------------------------------------
            //openweather API

            foreach (var item in response.weather)
            {

                output.Add(new WeatherForecast
                {
                    Name = response.name,
                    Date = DateTimeOffset.FromUnixTimeSeconds(response.dt).DateTime,
                    TemperatureC = Math.Round(Convert.ToDouble(response.main.temp) - 273.15, 2),
                    TemperatureF = Math.Round((Convert.ToDouble(response.main.temp) - 273.15) / 0.5556 + 32, 2),

                    Summary = item.description.ToUpper(),
                    //Image = item.description == "light rain" ? "https://cdn-icons-png.flaticon.com/128/4724/4724094.png" : string.Empty

                });
            }
            //------------------------------------------------------------------------------------------------------

            // weatherAPI

            //foreach (var item in response.forecast.forecastday)
            //{

            //    output.Add(new WeatherForecast
            //    {
            //        Name = response.location.name,
            //        Date = DateTime.Parse(response.location.localtime),

            //        TemperatureC = Math.Round(Convert.ToDouble(response.current.temp_c), 2),
            //        TemperatureF = Math.Round(Convert.ToDouble(response.current.temp_f), 2),
            //        Summary = response.current.condition.text,
            //        Image = response.current.condition.icon
            //    });
            //}



            //-------------------------------------------------------------------------------------------------------


            return output;
        }

        //-----------------------------------------------------------------------------------------------------
        //openweather API

        public class Clouds
        {
            public int all { get; set; }
        }

        public class Coord
        {
            public double lon { get; set; }
            public double lat { get; set; }
        }

        public class Main
        {
            public double temp { get; set; }
            public double feels_like { get; set; }
            public double temp_min { get; set; }
            public double temp_max { get; set; }
            public int pressure { get; set; }
            public int humidity { get; set; }
            public int sea_level { get; set; }
            public int grnd_level { get; set; }
        }

        public class Root
        {
            public Coord coord { get; set; }
            public List<Weather> weather { get; set; }
            public string @base { get; set; }
            public Main main { get; set; }
            public int visibility { get; set; }
            public Wind wind { get; set; }
            public Clouds clouds { get; set; }
            public int dt { get; set; }
            public Sys sys { get; set; }
            public int timezone { get; set; }
            public int id { get; set; }
            public string name { get; set; }
            public int cod { get; set; }
        }

        public class Sys
        {
            public int type { get; set; }
            public int id { get; set; }
            public string country { get; set; }
            public int sunrise { get; set; }
            public int sunset { get; set; }
        }

        public class Weather
        {
            public int id { get; set; }
            public string main { get; set; }
            public string description { get; set; }
            public string icon { get; set; }
        }

        public class Wind
        {
            public double speed { get; set; }
            public int deg { get; set; }
            public double gust { get; set; }
        }


        //------------------------------------------------------------------------------------------------------

        // weatherAPI




        //public class Astro
        //{
        //    public string sunrise { get; set; }
        //    public string sunset { get; set; }
        //    public string moonrise { get; set; }
        //    public string moonset { get; set; }
        //    public string moon_phase { get; set; }
        //    public int moon_illumination { get; set; }
        //    public int is_moon_up { get; set; }
        //    public int is_sun_up { get; set; }
        //}

        //public class Condition
        //{
        //    public string text { get; set; }
        //    public string icon { get; set; }
        //    public int code { get; set; }
        //}

        //public class Current
        //{
        //    public int last_updated_epoch { get; set; }
        //    public string last_updated { get; set; }
        //    public double temp_c { get; set; }
        //    public double temp_f { get; set; }
        //    public int is_day { get; set; }
        //    public Condition condition { get; set; }
        //    public double wind_mph { get; set; }
        //    public double wind_kph { get; set; }
        //    public int wind_degree { get; set; }
        //    public string wind_dir { get; set; }
        //    public double pressure_mb { get; set; }
        //    public double pressure_in { get; set; }
        //    public double precip_mm { get; set; }
        //    public double precip_in { get; set; }
        //    public int humidity { get; set; }
        //    public int cloud { get; set; }
        //    public double feelslike_c { get; set; }
        //    public double feelslike_f { get; set; }
        //    public double windchill_c { get; set; }
        //    public double windchill_f { get; set; }
        //    public double heatindex_c { get; set; }
        //    public double heatindex_f { get; set; }
        //    public double dewpoint_c { get; set; }
        //    public double dewpoint_f { get; set; }
        //    public double vis_km { get; set; }
        //    public double vis_miles { get; set; }
        //    public double uv { get; set; }
        //    public double gust_mph { get; set; }
        //    public double gust_kph { get; set; }
        //}

        //public class Day
        //{
        //    public double maxtemp_c { get; set; }
        //    public double maxtemp_f { get; set; }
        //    public double mintemp_c { get; set; }
        //    public double mintemp_f { get; set; }
        //    public double avgtemp_c { get; set; }
        //    public double avgtemp_f { get; set; }
        //    public double maxwind_mph { get; set; }
        //    public double maxwind_kph { get; set; }
        //    public double totalprecip_mm { get; set; }
        //    public double totalprecip_in { get; set; }
        //    public double totalsnow_cm { get; set; }
        //    public double avgvis_km { get; set; }
        //    public double avgvis_miles { get; set; }
        //    public int avghumidity { get; set; }
        //    public int daily_will_it_rain { get; set; }
        //    public int daily_chance_of_rain { get; set; }
        //    public int daily_will_it_snow { get; set; }
        //    public int daily_chance_of_snow { get; set; }
        //    public Condition condition { get; set; }
        //    public double uv { get; set; }
        //}

        //public class Forecast
        //{
        //    public List<Forecastday> forecastday { get; set; }
        //}

        //public class Forecastday
        //{
        //    public string date { get; set; }
        //    public int date_epoch { get; set; }
        //    public Day day { get; set; }
        //    public Astro astro { get; set; }
        //    public List<Hour> hour { get; set; }
        //}

        //public class Hour
        //{
        //    public int time_epoch { get; set; }
        //    public string time { get; set; }
        //    public double temp_c { get; set; }
        //    public double temp_f { get; set; }
        //    public int is_day { get; set; }
        //    public Condition condition { get; set; }
        //    public double wind_mph { get; set; }
        //    public double wind_kph { get; set; }
        //    public int wind_degree { get; set; }
        //    public string wind_dir { get; set; }
        //    public double pressure_mb { get; set; }
        //    public double pressure_in { get; set; }
        //    public double precip_mm { get; set; }
        //    public double precip_in { get; set; }
        //    public double snow_cm { get; set; }
        //    public int humidity { get; set; }
        //    public int cloud { get; set; }
        //    public double feelslike_c { get; set; }
        //    public double feelslike_f { get; set; }
        //    public double windchill_c { get; set; }
        //    public double windchill_f { get; set; }
        //    public double heatindex_c { get; set; }
        //    public double heatindex_f { get; set; }
        //    public double dewpoint_c { get; set; }
        //    public double dewpoint_f { get; set; }
        //    public int will_it_rain { get; set; }
        //    public int chance_of_rain { get; set; }
        //    public int will_it_snow { get; set; }
        //    public int chance_of_snow { get; set; }
        //    public double vis_km { get; set; }
        //    public double vis_miles { get; set; }
        //    public double gust_mph { get; set; }
        //    public double gust_kph { get; set; }
        //    public double uv { get; set; }
        //    public double short_rad { get; set; }
        //    public double diff_rad { get; set; }
        //}

        //public class Location
        //{
        //    public string name { get; set; }
        //    public string region { get; set; }
        //    public string country { get; set; }
        //    public double lat { get; set; }
        //    public double lon { get; set; }
        //    public string tz_id { get; set; }
        //    public int localtime_epoch { get; set; }
        //    public string localtime { get; set; }
        //}

        //public class Root
        //{
        //    public Location location { get; set; }
        //    public Current current { get; set; }
        //    public Forecast forecast { get; set; }
        //}
    }
}
