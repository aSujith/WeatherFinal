using System.Text.Json;
using System.Text;
using WeatherFinal.Components.Models;
namespace WeatherFinal.Components.Service
{
    public class UserValidationService
    {
        
        private const string ApiKey = "YOUR-SUPABASE-API-KEY";
        private const string BaseUrl = "https://hvwjempiyxudezvwpici.supabase.co";

        private readonly HttpClient _httpClient;

        public UserValidationService()
        {
            _httpClient = new HttpClient { BaseAddress = new Uri(BaseUrl) };
        }
        public async Task InsertDataAsync(SupabaseModel model)
        {
            try
            {
                string endpoint = $"/auth/v1/signup?apikey={ApiKey}";

                string jsonContent = JsonSerializer.Serialize(new
                {
                    email = model.Email,
                    password = model.Password
                });

                HttpContent httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PostAsync(endpoint, httpContent);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("User signed up successfully.");
                }
                else
                {
                    string errorResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Error during signup: {errorResponse}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An exception occurred: {ex.Message}");
            }
        }

        public async Task<bool> SignInAsync(string email, string password)
        {
            try
            {
                string endpoint = $"/auth/v1/token?grant_type=password&apikey={ApiKey}";

                var signInData = new
                {
                    email = email,
                    password = password
                };

                string jsonContent = JsonSerializer.Serialize(signInData);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(endpoint, content);

                if (response.IsSuccessStatusCode)
                {

                    Console.WriteLine("Sign in successful!");
                    return true;
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Sign in failed. Error: {error}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
        }
    }
}
