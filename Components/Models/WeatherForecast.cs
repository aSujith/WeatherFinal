namespace WeatherFinal.Components.Models
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public string Name { get; set; }

        public double TemperatureC { get; set; }

        public double TemperatureF { get; set; }

        public string? Summary { get; set; }

        public string Image { get; set; }

    }
}
