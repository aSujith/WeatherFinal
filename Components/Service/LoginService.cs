
using MongoDB.Driver;
using WeatherFinal.Components.Models;

namespace WeatherFinal.Components.Service
{
    public class LoginService
    {
        private readonly IMongoCollection<RegisterModel> _userCollection;

        public LoginService()
        {
            var client = new MongoClient("mongodb://localhost:27017/");
            var database = client.GetDatabase("Mudblazor");
            _userCollection = database.GetCollection<RegisterModel>("registerData");
        }

        public async Task<bool> AuthenticateUserAsync(string username, string password)
        {
            try
            {
                var filter = Builders<RegisterModel>.Filter.And(
                    Builders<RegisterModel>.Filter.Eq(u => u.Name, username),
                    Builders<RegisterModel>.Filter.Eq(u => u.Password, password) 
                );

                var user = await _userCollection.Find(filter).FirstOrDefaultAsync();

                if (user == null)
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error during login: " + ex.Message);
                return false;
            }
        }
    }
}
