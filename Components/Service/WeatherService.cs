using MongoDB.Bson;
using MongoDB.Driver;
using WeatherFinal.Components.Models;
namespace WeatherFinal.Components.Service
{
    public class WeatherService
    {
        private readonly IMongoClient _client;
        private readonly IMongoCollection<WeatherModel> _weatherCollection;

        public WeatherService(IConfiguration configuration)
        {
            _client = new MongoClient("mongodb://localhost:27017/");
            var database = _client.GetDatabase("Mudblazor");
            _weatherCollection = database.GetCollection<WeatherModel>("weatherData");
        }

        public async Task<List<WeatherModel>> GetweathersAsync()
        {
            return await _weatherCollection.Find(new BsonDocument()).ToListAsync();
        }


    }
}



