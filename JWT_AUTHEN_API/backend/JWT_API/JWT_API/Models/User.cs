using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace JWT_API.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        [JsonIgnore]
        public string? Password { get; set; }
    }
}
