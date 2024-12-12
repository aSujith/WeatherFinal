using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
namespace WeatherFinal.Components.Models
{
    public class RegisterModel
    {
        public ObjectId Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Phone { get; set; }

        public List<string> FavCity { get; set; } = new List<string>();
    }
}
