using Newtonsoft.Json;

namespace Security.Application.DTOs
{
    public class UserDto
    {
        public UserDto() { }

        public UserDto(string name, string email, int id)
        {
            this.Id = id;
            this.Name = name;
            this.Email = email;
            this.Email = email;
        }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }
    }
}
