using MongoDB.Bson;
namespace WeatherFinal.Components.Models
{
    public class WeatherModel
    {
        public ObjectId id {  get; set; }
        public string Date { get; set; }

        public string City { get; set; }
        public double Temp_C {  get; set; }
        public string Summery {  get; set; }
    }
}
