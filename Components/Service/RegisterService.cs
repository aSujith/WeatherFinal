using MongoDB.Bson;
using MongoDB.Driver;
using WeatherFinal.Components.Models;

namespace WeatherFinal.Components.Service
{
    public class RegisterService
    {
        private readonly IMongoCollection<RegisterModel> _registerCollection;

        public RegisterService()
        {
            var client = new MongoClient("mongodb://localhost:27017/");
            var database = client.GetDatabase("Mudblazor");
            _registerCollection = database.GetCollection<RegisterModel>("registerData");
        }
        public async Task<List<RegisterModel>> GetDataAsync()
        {
            return await _registerCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task InsertDataAsync(RegisterModel register)
        {
            try
            {
                await _registerCollection.InsertOneAsync(register);
                Console.WriteLine("Data inserted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while inserting data: {ex.Message}");
                throw; 
            }
        }
        public async Task<RegisterModel> GetUserAsync(string userName)
        {
            var filter = Builders<RegisterModel>.Filter.Eq("Name", userName);
            return await _registerCollection.Find(filter).FirstOrDefaultAsync();
        }
        public async Task AddCityToFavoritesAsync(string userName, string cityName)
        {
            try
            {
                var user = await GetUserAsync(userName);

                if (user == null)
                {
                    throw new Exception("User not found.");
                }

                if (user.FavCity == null)
                {
                    var initializeFavCity = Builders<RegisterModel>.Update.Set(user => user.FavCity, new List<string>());
                    await _registerCollection.UpdateOneAsync(
                        Builders<RegisterModel>.Filter.Eq("Name", userName), initializeFavCity
                    );

                    user = await GetUserAsync(userName);
                }

                if (!user.FavCity.Contains(cityName))
                {
                    var update = Builders<RegisterModel>.Update.AddToSet("FavCity", cityName);

                    var result = await _registerCollection.UpdateOneAsync(
                        Builders<RegisterModel>.Filter.Eq("Name", userName), update
                    );

                    if (result.ModifiedCount > 0)
                    {
                        Console.WriteLine("City added to favorites successfully.");
                    }
                    else
                    {
                        Console.WriteLine("No changes made to the user's favorites.");
                    }
                }
                else
                {
                    Console.WriteLine("City already exists in the favorites.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while updating favorites: {ex.Message}");
                throw;
            }
        }

    }
}
